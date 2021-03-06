using Mutagen.Bethesda.Plugins;

namespace Mutagen.Bethesda.Oblivion.Internals
{
    public class RecordTypes
    {
        public static readonly RecordType ACBS = new RecordType(0x53424341);
        public static readonly RecordType ACHR = new RecordType(0x52484341);
        public static readonly RecordType ACRE = new RecordType(0x45524341);
        public static readonly RecordType ACTI = new RecordType(0x49544341);
        public static readonly RecordType AIDT = new RecordType(0x54444941);
        public static readonly RecordType ALCH = new RecordType(0x48434C41);
        public static readonly RecordType AMMO = new RecordType(0x4F4D4D41);
        public static readonly RecordType ANAM = new RecordType(0x4D414E41);
        public static readonly RecordType ANIO = new RecordType(0x4F494E41);
        public static readonly RecordType APPA = new RecordType(0x41505041);
        public static readonly RecordType ARMO = new RecordType(0x4F4D5241);
        public static readonly RecordType ATTR = new RecordType(0x52545441);
        public static readonly RecordType ATXT = new RecordType(0x54585441);
        public static readonly RecordType BMDT = new RecordType(0x54444D42);
        public static readonly RecordType BNAM = new RecordType(0x4D414E42);
        public static readonly RecordType BOOK = new RecordType(0x4B4F4F42);
        public static readonly RecordType BSGN = new RecordType(0x4E475342);
        public static readonly RecordType BTXT = new RecordType(0x54585442);
        public static readonly RecordType CELL = new RecordType(0x4C4C4543);
        public static readonly RecordType CLAS = new RecordType(0x53414C43);
        public static readonly RecordType CLMT = new RecordType(0x544D4C43);
        public static readonly RecordType CLOT = new RecordType(0x544F4C43);
        public static readonly RecordType CNAM = new RecordType(0x4D414E43);
        public static readonly RecordType CNTO = new RecordType(0x4F544E43);
        public static readonly RecordType CONT = new RecordType(0x544E4F43);
        public static readonly RecordType CREA = new RecordType(0x41455243);
        public static readonly RecordType CSAD = new RecordType(0x44415343);
        public static readonly RecordType CSCR = new RecordType(0x52435343);
        public static readonly RecordType CSDC = new RecordType(0x43445343);
        public static readonly RecordType CSDI = new RecordType(0x49445343);
        public static readonly RecordType CSDT = new RecordType(0x54445343);
        public static readonly RecordType CSTD = new RecordType(0x44545343);
        public static readonly RecordType CSTY = new RecordType(0x59545343);
        public static readonly RecordType CTDA = new RecordType(0x41445443);
        public static readonly RecordType CTDT = new RecordType(0x54445443);
        public static readonly RecordType DATA = new RecordType(0x41544144);
        public static readonly RecordType DELE = new RecordType(0x454C4544);
        public static readonly RecordType DESC = new RecordType(0x43534544);
        public static readonly RecordType DIAL = new RecordType(0x4C414944);
        public static readonly RecordType DNAM = new RecordType(0x4D414E44);
        public static readonly RecordType DOOR = new RecordType(0x524F4F44);
        public static readonly RecordType EFID = new RecordType(0x44494645);
        public static readonly RecordType EFIT = new RecordType(0x54494645);
        public static readonly RecordType EFSH = new RecordType(0x48534645);
        public static readonly RecordType ENAM = new RecordType(0x4D414E45);
        public static readonly RecordType ENCH = new RecordType(0x48434E45);
        public static readonly RecordType ENIT = new RecordType(0x54494E45);
        public static readonly RecordType ESCE = new RecordType(0x45435345);
        public static readonly RecordType EYES = new RecordType(0x53455945);
        public static readonly RecordType FACT = new RecordType(0x54434146);
        public static readonly RecordType FGGA = new RecordType(0x41474746);
        public static readonly RecordType FGGS = new RecordType(0x53474746);
        public static readonly RecordType FGTS = new RecordType(0x53544746);
        public static readonly RecordType FLOR = new RecordType(0x524F4C46);
        public static readonly RecordType FLTV = new RecordType(0x56544C46);
        public static readonly RecordType FNAM = new RecordType(0x4D414E46);
        public static readonly RecordType FULL = new RecordType(0x4C4C5546);
        public static readonly RecordType FURN = new RecordType(0x4E525546);
        public static readonly RecordType GLOB = new RecordType(0x424F4C47);
        public static readonly RecordType GMST = new RecordType(0x54534D47);
        public static readonly RecordType GNAM = new RecordType(0x4D414E47);
        public static readonly RecordType GRAS = new RecordType(0x53415247);
        public static readonly RecordType GRUP = new RecordType(0x50555247);
        public static readonly RecordType HAIR = new RecordType(0x52494148);
        public static readonly RecordType HCLR = new RecordType(0x524C4348);
        public static readonly RecordType HEDR = new RecordType(0x52444548);
        public static readonly RecordType HNAM = new RecordType(0x4D414E48);
        public static readonly RecordType ICO2 = new RecordType(0x324F4349);
        public static readonly RecordType ICON = new RecordType(0x4E4F4349);
        public static readonly RecordType IDLE = new RecordType(0x454C4449);
        public static readonly RecordType INAM = new RecordType(0x4D414E49);
        public static readonly RecordType INDX = new RecordType(0x58444E49);
        public static readonly RecordType INFO = new RecordType(0x4F464E49);
        public static readonly RecordType INGR = new RecordType(0x52474E49);
        public static readonly RecordType JNAM = new RecordType(0x4D414E4A);
        public static readonly RecordType KEYM = new RecordType(0x4D59454B);
        public static readonly RecordType KFFZ = new RecordType(0x5A46464B);
        public static readonly RecordType LAND = new RecordType(0x444E414C);
        public static readonly RecordType LIGH = new RecordType(0x4847494C);
        public static readonly RecordType LNAM = new RecordType(0x4D414E4C);
        public static readonly RecordType LSCR = new RecordType(0x5243534C);
        public static readonly RecordType LTEX = new RecordType(0x5845544C);
        public static readonly RecordType LVLC = new RecordType(0x434C564C);
        public static readonly RecordType LVLD = new RecordType(0x444C564C);
        public static readonly RecordType LVLF = new RecordType(0x464C564C);
        public static readonly RecordType LVLI = new RecordType(0x494C564C);
        public static readonly RecordType LVLO = new RecordType(0x4F4C564C);
        public static readonly RecordType LVSP = new RecordType(0x5053564C);
        public static readonly RecordType MAST = new RecordType(0x5453414D);
        public static readonly RecordType MGEF = new RecordType(0x4645474D);
        public static readonly RecordType MISC = new RecordType(0x4353494D);
        public static readonly RecordType MNAM = new RecordType(0x4D414E4D);
        public static readonly RecordType MOD2 = new RecordType(0x32444F4D);
        public static readonly RecordType MOD3 = new RecordType(0x33444F4D);
        public static readonly RecordType MOD4 = new RecordType(0x34444F4D);
        public static readonly RecordType MODB = new RecordType(0x42444F4D);
        public static readonly RecordType MODL = new RecordType(0x4C444F4D);
        public static readonly RecordType MODT = new RecordType(0x54444F4D);
        public static readonly RecordType NAM0 = new RecordType(0x304D414E);
        public static readonly RecordType NAM1 = new RecordType(0x314D414E);
        public static readonly RecordType NAM2 = new RecordType(0x324D414E);
        public static readonly RecordType NAM9 = new RecordType(0x394D414E);
        public static readonly RecordType NAME = new RecordType(0x454D414E);
        public static readonly RecordType NIFT = new RecordType(0x5446494E);
        public static readonly RecordType NIFZ = new RecordType(0x5A46494E);
        public static readonly RecordType NPC_ = new RecordType(0x5F43504E);
        public static readonly RecordType OFST = new RecordType(0x5453464F);
        public static readonly RecordType ONAM = new RecordType(0x4D414E4F);
        public static readonly RecordType PACK = new RecordType(0x4B434150);
        public static readonly RecordType PFIG = new RecordType(0x47494650);
        public static readonly RecordType PFPC = new RecordType(0x43504650);
        public static readonly RecordType PGAG = new RecordType(0x47414750);
        public static readonly RecordType PGRD = new RecordType(0x44524750);
        public static readonly RecordType PGRI = new RecordType(0x49524750);
        public static readonly RecordType PGRL = new RecordType(0x4C524750);
        public static readonly RecordType PGRP = new RecordType(0x50524750);
        public static readonly RecordType PKDT = new RecordType(0x54444B50);
        public static readonly RecordType PKID = new RecordType(0x44494B50);
        public static readonly RecordType PLDT = new RecordType(0x54444C50);
        public static readonly RecordType PNAM = new RecordType(0x4D414E50);
        public static readonly RecordType PSDT = new RecordType(0x54445350);
        public static readonly RecordType PTDT = new RecordType(0x54445450);
        public static readonly RecordType QNAM = new RecordType(0x4D414E51);
        public static readonly RecordType QSDT = new RecordType(0x54445351);
        public static readonly RecordType QSTA = new RecordType(0x41545351);
        public static readonly RecordType QSTI = new RecordType(0x49545351);
        public static readonly RecordType QUST = new RecordType(0x54535551);
        public static readonly RecordType RACE = new RecordType(0x45434152);
        public static readonly RecordType RCLR = new RecordType(0x524C4352);
        public static readonly RecordType RDAT = new RecordType(0x54414452);
        public static readonly RecordType RDGS = new RecordType(0x53474452);
        public static readonly RecordType RDMD = new RecordType(0x444D4452);
        public static readonly RecordType RDMP = new RecordType(0x504D4452);
        public static readonly RecordType RDOT = new RecordType(0x544F4452);
        public static readonly RecordType RDSD = new RecordType(0x44534452);
        public static readonly RecordType RDWT = new RecordType(0x54574452);
        public static readonly RecordType REFR = new RecordType(0x52464552);
        public static readonly RecordType REGN = new RecordType(0x4E474552);
        public static readonly RecordType RNAM = new RecordType(0x4D414E52);
        public static readonly RecordType ROAD = new RecordType(0x44414F52);
        public static readonly RecordType RPLD = new RecordType(0x444C5052);
        public static readonly RecordType RPLI = new RecordType(0x494C5052);
        public static readonly RecordType SBSP = new RecordType(0x50534253);
        public static readonly RecordType SCDA = new RecordType(0x41444353);
        public static readonly RecordType SCHD = new RecordType(0x44484353);
        public static readonly RecordType SCHR = new RecordType(0x52484353);
        public static readonly RecordType SCIT = new RecordType(0x54494353);
        public static readonly RecordType SCPT = new RecordType(0x54504353);
        public static readonly RecordType SCRI = new RecordType(0x49524353);
        public static readonly RecordType SCRO = new RecordType(0x4F524353);
        public static readonly RecordType SCRV = new RecordType(0x56524353);
        public static readonly RecordType SCTX = new RecordType(0x58544353);
        public static readonly RecordType SCVR = new RecordType(0x52564353);
        public static readonly RecordType SGST = new RecordType(0x54534753);
        public static readonly RecordType SKIL = new RecordType(0x4C494B53);
        public static readonly RecordType SLCP = new RecordType(0x50434C53);
        public static readonly RecordType SLGM = new RecordType(0x4D474C53);
        public static readonly RecordType SLSD = new RecordType(0x44534C53);
        public static readonly RecordType SNAM = new RecordType(0x4D414E53);
        public static readonly RecordType SNDD = new RecordType(0x44444E53);
        public static readonly RecordType SNDX = new RecordType(0x58444E53);
        public static readonly RecordType SOUL = new RecordType(0x4C554F53);
        public static readonly RecordType SOUN = new RecordType(0x4E554F53);
        public static readonly RecordType SPEL = new RecordType(0x4C455053);
        public static readonly RecordType SPIT = new RecordType(0x54495053);
        public static readonly RecordType SPLO = new RecordType(0x4F4C5053);
        public static readonly RecordType STAT = new RecordType(0x54415453);
        public static readonly RecordType TCLF = new RecordType(0x464C4354);
        public static readonly RecordType TCLT = new RecordType(0x544C4354);
        public static readonly RecordType TES4 = new RecordType(0x34534554);
        public static readonly RecordType TNAM = new RecordType(0x4D414E54);
        public static readonly RecordType TRDT = new RecordType(0x54445254);
        public static readonly RecordType TREE = new RecordType(0x45455254);
        public static readonly RecordType UNAM = new RecordType(0x4D414E55);
        public static readonly RecordType VCLR = new RecordType(0x524C4356);
        public static readonly RecordType VHGT = new RecordType(0x54474856);
        public static readonly RecordType VNAM = new RecordType(0x4D414E56);
        public static readonly RecordType VNML = new RecordType(0x4C4D4E56);
        public static readonly RecordType VTEX = new RecordType(0x58455456);
        public static readonly RecordType VTXT = new RecordType(0x54585456);
        public static readonly RecordType WATR = new RecordType(0x52544157);
        public static readonly RecordType WEAP = new RecordType(0x50414557);
        public static readonly RecordType WLST = new RecordType(0x54534C57);
        public static readonly RecordType WNAM = new RecordType(0x4D414E57);
        public static readonly RecordType WRLD = new RecordType(0x444C5257);
        public static readonly RecordType WTHR = new RecordType(0x52485457);
        public static readonly RecordType XACT = new RecordType(0x54434158);
        public static readonly RecordType XCCM = new RecordType(0x4D434358);
        public static readonly RecordType XCHG = new RecordType(0x47484358);
        public static readonly RecordType XCLC = new RecordType(0x434C4358);
        public static readonly RecordType XCLL = new RecordType(0x4C4C4358);
        public static readonly RecordType XCLR = new RecordType(0x524C4358);
        public static readonly RecordType XCLW = new RecordType(0x574C4358);
        public static readonly RecordType XCMT = new RecordType(0x544D4358);
        public static readonly RecordType XCNT = new RecordType(0x544E4358);
        public static readonly RecordType XCWT = new RecordType(0x54574358);
        public static readonly RecordType XESP = new RecordType(0x50534558);
        public static readonly RecordType XGLB = new RecordType(0x424C4758);
        public static readonly RecordType XHLT = new RecordType(0x544C4858);
        public static readonly RecordType XHRS = new RecordType(0x53524858);
        public static readonly RecordType XLCM = new RecordType(0x4D434C58);
        public static readonly RecordType XLOC = new RecordType(0x434F4C58);
        public static readonly RecordType XLOD = new RecordType(0x444F4C58);
        public static readonly RecordType XMRC = new RecordType(0x43524D58);
        public static readonly RecordType XMRK = new RecordType(0x4B524D58);
        public static readonly RecordType XNAM = new RecordType(0x4D414E58);
        public static readonly RecordType XOWN = new RecordType(0x4E574F58);
        public static readonly RecordType XPCI = new RecordType(0x49435058);
        public static readonly RecordType XRGD = new RecordType(0x44475258);
        public static readonly RecordType XRNK = new RecordType(0x4B4E5258);
        public static readonly RecordType XRTM = new RecordType(0x4D545258);
        public static readonly RecordType XSCL = new RecordType(0x4C435358);
        public static readonly RecordType XSED = new RecordType(0x44455358);
        public static readonly RecordType XSOL = new RecordType(0x4C4F5358);
        public static readonly RecordType XTEL = new RecordType(0x4C455458);
        public static readonly RecordType XTRG = new RecordType(0x47525458);
        public static readonly RecordType XXXX = new RecordType(0x58585858);
        public static readonly RecordType ZNAM = new RecordType(0x4D414E5A);
    }
}
