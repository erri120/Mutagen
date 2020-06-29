using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Mutagen.Bethesda
{
    /// <summary>
    /// A string that can be represented in multiple different languages.<br/>
    /// Threadsafe.
    /// </summary>
    public class TranslatedString : ITranslatedString
    {
        /// <summary>
        /// The default language to use as the main target language
        /// </summary>
        public static Language DefaultLanguage = Language.English;

        /// <summary>
        /// Language the string is targeting, and will be set/return when accessed normally
        /// </summary>
        public Language TargetLanguage { get; }

        private string? _directString;
        private readonly object _lock = new object();
        private Dictionary<Language, string?>? _localization;

        // Alternate way of populating a Translated String
        // Will cause it to act in a lazy lookup fashion
        internal uint Key;
        internal IStringsFolderLookup? StringsLookup;
        internal StringsSource StringsSource;

        /// <inheritdoc />
        public string String
        {
            get
            {
                lock (_lock)
                {
                    if (_directString != null) return _directString;
                    if (TryLookup(TargetLanguage, out var str))
                    {
                        return str;
                    }
                    return string.Empty;
                }
            }
            set => Set(TargetLanguage, value);
        }

        /// <summary>
        /// Creates a translated string with empty string set for the default language
        /// </summary>
        /// <param name="language">Optional target language override</param>
        public TranslatedString(Language? language = null)
        {
            TargetLanguage = language ?? DefaultLanguage;
        }

        /// <summary>
        /// Creates a translated string with a value for the default language
        /// </summary>
        /// <param name="directString">String to register for the default language</param>
        /// <param name="language">Optional target language override</param>
        public TranslatedString(string directString, Language? language = null)
        {
            _directString = directString;
            TargetLanguage = language ?? DefaultLanguage;
        }

        /// <summary>
        /// Creates a translated string with a number of strings for languages.
        /// If no string is provided for the default language, string.Empty will be assigned.
        /// </summary>
        /// <param name="strs">Language string pairs to register</param>
        /// <param name="language">Optional target language override</param>
        public TranslatedString(IEnumerable<KeyValuePair<Language, string>> strs, Language? language = null)
        {
            _localization = new Dictionary<Language, string?>();
            foreach (var str in strs)
            {
                _localization[str.Key] = str.Value;
            }
            TargetLanguage = language ?? DefaultLanguage;
        }

        /// <summary>
        /// Creates a translated string with a number of strings for languages.
        /// If no string is provided for the default language, string.Empty will be assigned.
        /// </summary>
        /// <param name="language">Target language override</param>
        /// <param name="strs">Language string pairs to register</param>
        public TranslatedString(Language language, params KeyValuePair<Language, string>[] strs)
            : this((IEnumerable<KeyValuePair<Language, string>>)strs, language)
        {
        }

        /// <summary>
        /// Creates a translated string with a number of strings for languages.
        /// If no string is provided for the default language, string.Empty will be assigned.
        /// </summary>
        /// <param name="strs">Language string pairs to register</param>
        public TranslatedString(params KeyValuePair<Language, string>[] strs)
            : this((IEnumerable<KeyValuePair<Language, string>>)strs, language: null)
        {
        }

        /// <inheritdoc />
        public bool TryLookup(Language language, [MaybeNullWhen(false)] out string str)
        {
            if (TargetLanguage == language
                && _directString != null)
            {
                str = _directString;
                return true;
            }

            lock (_lock)
            {
                if (_localization != null
                    && _localization.TryGetValue(language, out str))
                {
                    return str != null;
                }
                else if (StringsLookup != null)
                {
                    if (_localization == null)
                    {
                        _localization = new Dictionary<Language, string?>();
                    }
                    if (StringsLookup.TryLookup(this.StringsSource, language, this.Key, out str))
                    {
                        _localization[language] = str;
                        return true;
                    }
                    else
                    {
                        _localization[language] = null;
                        return false;
                    }
                }
            }

            str = default;
            return false;
        }

        /// <summary>
        /// Sets the string for a specific language
        /// </summary>
        /// <param name="language">Language to register the string under</param>
        /// <param name="str">String to register</param>
        public void Set(Language language, string str)
        {
            lock (_lock)
            {
                if (_localization == null)
                {
                    if (language == TargetLanguage)
                    {
                        _directString = str;
                        return;
                    }

                    _localization = CreateLocalization();
                }
                _localization[language] = str;
            }
        }

        /// <inheritdoc />
        public void RemoveNonDefault(Language language)
        {
            if (language == TargetLanguage) return;
            lock (_lock)
            {
                if (_localization == null)
                {
                    _localization = CreateLocalization();
                }
                _localization[language] = null;
            }
        }

        private Dictionary<Language, string?> CreateLocalization()
        {
            var ret = new Dictionary<Language, string?>();

            // If we already have a direct string, swap to the internal setup where it's stored in the dictionary
            if (_directString != null)
            {
                ret[TargetLanguage] = _directString;
                _directString = null;
            }
            return ret;
        }

        /// <inheritdoc />
        public void ClearNonDefault()
        {
            lock (_lock)
            {
                if (_localization == null) return;
                if (!_localization.TryGetValue(TargetLanguage, out _directString))
                {
                    _directString = string.Empty;
                }
                _localization = null;
            }
        }

        /// <inheritdoc />
        public void Clear()
        {
            ClearNonDefault();
            this._directString = null;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public IEnumerator<KeyValuePair<Language, string>> GetEnumerator()
        {
            lock (_lock)
            {
                if (StringsLookup == null)
                {
                    if (_localization == null)
                    {
                        if (_directString != null)
                        {
                            yield return new KeyValuePair<Language, string>(TargetLanguage, _directString);
                        }
                        yield break;
                    }
                    else
                    {
                        if (_directString != null && !_localization.ContainsKey(TargetLanguage))
                        {
                            yield return new KeyValuePair<Language, string>(TargetLanguage, _directString);
                        }
                        foreach (var item in _localization)
                        {
                            if (item.Value == null) continue;
                            yield return new KeyValuePair<Language, string>(item.Key, item.Value);
                        }
                    }
                }
                else
                {
                    if (_directString != null)
                    {
                        yield return new KeyValuePair<Language, string>(TargetLanguage, _directString);
                    }

                    foreach (var lang in StringsLookup.AvailableLanguages(StringsSource))
                    {
                        if (_localization != null
                            && _localization.TryGetValue(lang, out var langStr))
                        {
                            if (langStr != null)
                            {
                                yield return new KeyValuePair<Language, string>(lang, langStr);
                            }
                        }
                        else
                        {
                            if (StringsLookup.TryLookup(StringsSource, lang, Key, out var str))
                            {
                                yield return new KeyValuePair<Language, string>(lang, str);
                            }
                        }
                    }
                }
            }
        }

        public static implicit operator TranslatedString(string str)
        {
            return new TranslatedString(str);
        }

        public override string ToString()
        {
            return this.String;
        }
    }
}
