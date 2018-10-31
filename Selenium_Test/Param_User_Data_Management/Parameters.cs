using SAFINCA.CommonFuncMgn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFINCA.ParameterAndUserDataMgn
{
    class Parameters
    {
        //TEST DATA
        public static string PRODUCT_STRUCTURE = "Product Structure";
        public static string PART_REFERENCE = "Part Reference";
        public static string ENOVIA_PART_NUMBER = "ENOVIA Part Number";
        public static string DOCUMENT_REVISION = "Document Revision";
        public static string DOCUMENT_ID = "Document ID";

        public static string RIGHT_CLICK_POPUP_MENU_LOAD_IN_2D_VIEWER = "Load in 2D Viewer";
        public static string RIGHT_CLICK_POPUP_MENU_LOAD_IN_3D_VIEWER = "Load in 3D Viewer";
        public static string DESIGNER_UTE_Sogeti = "DESIGNER.UTE.Sogeti";
        public static string TEST_PARTNER_01_AUTO_TESTS = "Test Partner 01 - auto tests";
        public static string SHRIDHAR_TEST_SANJEEVI = "Shridhar Test Sanjeevi";
        public static string CONTENT_MANAGEMENT = "Content Management";


        ///USER DATA, EXCEL
        public static string UD_USER_NAME = "UD_USER_NAME";
        public static string UD_PASSWORD = "UD_PASSWORD";
        public static string UD_DOMAIN_PASSWORD = "UD_DOMAIN_PASSWORD";
        public static string UD_ROLE = "UD_ROLE";

        public static string TD_GEN_OBJECTS = "TD_GEN_Objects";
        public static string TD_GEN_DOMAINS = "TD_GEN_Domains";
        public static string TD_226_20_SPARTTYPE = "TD_226_20_SPartType";
        public static string TD_226_20_CPARTTYPE = "TD_226_20_CPartType";
        public static string TD_226_20_DESCRIPTION = "TD_226_20_Description";
        public static string TD_226_31_SPARTTYPE = "TD_226_31_SPartType";
        public static string TD_226_31_CPARTTYPE = "TD_226_31_CPartType";
        public static string TD_226_31_DESCRIPTION = "TD_226_31_Description";
        public static string TD_226_00_SPARTTYPE = "TD_226_00_SPartType";
        public static string TD_226_00_CPartType = "TD_226_00_Description";
        public static string TD_226_00_INSTANCE = "TD_226_00_Instance";
        public static string TD_226_00_REFERENCE = "TD_226_00_Reference";
        public static string TD_226_00_DOCUMENT = "TD_226_00_Document";
        public static string TD_SV_QUERY = "TD_SV_Query";
        public static string TD_SV_PARTNUMBER = "TD_SV_PartNumber";
        public static string TD_SV_CHASSI_NUMBER = "TD_SV_CHASSI_NUMBER";

        public static string ROW_ZERO = "0";
        public static string ROW_ONE = "1";
        public static string ROW_TWO = "2";
        public static string ROW_THREE = "3";
        public static string ROW_FOUR = "4";
        public static string ROW_FIVE = "5";
        public static string ROW_SIX = "6";
        public static string ROW_SEVEN = "7";
        public static string ROW_EIGHT = "8";
        public static string ROW_NINE = "9";
        public static string ROW_TEN = "10";
        public static string ROW_ELEVEN = "11";
        public static string ROW_TWELV = "12";
        public static string ROW_THERTEEN = "13";
        public static string ROW_FOURTEEN = "14";
        public static string ROW_FIFTEEN = "15";
        public static string TEST = "TEST";
        public static string PROD = "PROD";
        public static string ACC = "ACC";
        public static string CUS = "CUS";
        
        public static string NAME_IN_GRAPH = "..'Name in graph'=";
        public static string ASTERISK_CHAR = "*";
        public static string UNDERSCORE_CHAR = "_";
        public static string EQUALS_CHAR = "=";
        public static string NULL_CHAR = "";
        public static string HYPHEN_CHAR = "-";
        public static string SINGLEQUOTE_CHAR = "'";
        public static string COMMA_CHAR = ",";

        //************FileBasedImport
        //PopmenuOption in FBI window
        public static string DELETE_ROW = "DELETE_ROW";
        public static string Sogeti_PART_NUMBER = "Sogeti Part Number";
        public static string PART_NUMBER = "Part Number";
        public static string PART_TYPE = "Part Type";
        public static string FILE_NAME = "File Name";
        public static string FILE_EXTENSION = "File extension";
        public static string REMOVED = "Removed";
        public static string SHEET_NUMBER = "Sheet Number";
        public static string DESCRIPTION = "Description";
        public static string PARTAXIS_1_CATPART = "PartAxis_1.CATPart";
        public static string THUMBS_DB = "Thumbs.db";
        public static string V5 = "V5";
        public static string NonV5 = "NonV5";
        public static string AC = "AC";
        public static string VR = "VR";


        public static string TESTDATA_FOLDER_PATH_BASE_NAME = @"\\global.scd.Sogeti.com\proj\C\CATIAV5\MAX_MAINTENANCE\MAX_1\Test\TestData\SAFAutomation";

        //Native formats to convert
        public const string FROM_FORMAT_CATPART_NAME = "CATPart";
        public const string FROM_FORMAT_CATPRODUCT_NAME = "CATProduct";
        public const string FROM_FORMAT_CATDRAWING_NAME = "CATDrawing";

        //conversion formats for CATProduct and CATPart
        public static string CONVERSION_FORMATS_CATIA_MODEL_NAME = "Catia Model (2D/3D)";
        public static string CONVERSION_FORMATS_STEP_AP203_NAME = "STEP AP203 (3D)";
        public static string CONVERSION_FORMATS_STEP_AP214_NAME = "STEP AP214 (3D)";
        public static string CONVERSION_FORMATS_IGES_3D_NAME = "IGES (3D)";
        public static string CONVERSION_FORMATS_JT_3D_NAME = "JT (3D)";
        public static string CONVERSION_FORMATS_3DXML_3D_NAME = "3DXML (3D)";

        //conversion formats for CATDrawing
        public static string CONVERSION_FORMATS_IGES_2D_NAME = "IGES (2D)";
        public static string CONVERSION_FORMATS_DXF_2D_NAME = "DXF (2D)";
        public static string CONVERSION_FORMATS_PDF_2D_NAME = "PDF (2D)";
        public static string GROUP_ROWS = "GROUP_ROWS";
        public static string GROUP_ROWSTWO = "GROUP_ROWSTWO";

        public static string ASSEMBLYDRAWING = "AssemblyDrawing";
        public static string BLACKBOX = "Black Box";


        public static string SAF_SYSTEMVERIFICATION = "SAF_SYSTEMVERIFICATION";

        //VPM Search Attributes

        //Webdrivers
        public static string InternetExplorerDriver = "InternetExplorerDriver";
        public static string FireFoxDriver = "FireFoxDriver";
        public static string ChromeDriver = "ChromeDriver";

        public static string InternetExplorerDriverProcessName = "iexplore";
        public static string FireFoxDriverProcessName = "firefox";
        public static string ChromeDriverProcessName = "chrome";

        public static string R19 = "R19";
        public static string R24 = "R24";

        public static string cmdOpen = "C:Open";
        public static string cmdClose = "C:Close";
        public static string cmdDelete = "C:Delete";
        public static string cmdExpandAll = "C:Expand All";
        public static string cmdSaveInENOVIAV5VPM = "C:save in ENOVIA V5 VPM ...";
        public static string cmdCreateNewSogetiDocument = "c:create new Sogeti document";
        public static string cmdSCVSelectTitleBlock = "c:scvselecttitleblockcmd";
        public static string cmdRefreshAndCollapse = "c:Refresh and collapse";
        public static string cmdSupportPortal = "c:support portal";
        public static string cmdProperties = "c:properties";
        public static string cmdLock = "c:Lock";
        public static string cmdUnLock = "c:UnLock";
        public static string cmdSelectUnder = "c:Select Under";
        public static string cmdExpandAllLevel = "C: Expand All Levels";        
        public static string cmdExpandFirstLevel = "C: Expand First Level";
        public static string cmdExpandSecondLevel = "C: Expand Second Level";
        
        public static string cmdSessionInformation = "C:Session Information";

        public static string SAF_SV = "SAF_SV";

        public static string SCVDetailDrawing = "SCVDetailDrawing"; //drawing document window name while creating for first time
        public static string NORMAL = "Normal"; // titleblock type
        public static string DetailDrawing = "DetailDrawing";// document type
        public static string Simplified = "Simplified"; // titleblock type
        public static string Reporting = "Reporting"; // Reporting window
        public static string FAD210 = "210";
        public static string FAD224 = "224";

        //ListItem in the dropdown in the V5 support portal
        public static string SCVSetDocStatus = "SCVSetDocStatus.ksh";
        public static string SCVSetPartStatus = "SCVSetPartStatus.ksh";

        //PNG file name for V5 support portal window
        public static string DocId_PNG = "DocId.png";
        public static string Revision_PNG = "Revision.png";
        public static string PartId_PNG = "PartId.png";
        public static string Version_PNG = "Version.png";
        public static string Status_PNG = "Status.png";
        public static string LOCK = "LOCK";
        public static string UNLOCK = "UNLOCK";

        public static string DOC_PROPERTIES = "DOC_PROPERTIES";// popup menu for document window
        public static string PART_PROPERTIES = "PART_PROPERTIES";// popup menu for Part  window
        public static string PART_DELETE = "PART_DELETE";
        public static string DOC_DELETE = "DOC_DELETE";

        //Ctrl-M catalogue
        public static string ENOV_TO_MOD_B19 = "ENOV_TO_MOD_B19";
        public static string ENOV_TO_MOD_B24 = "ENOV_TO_MOD_B24";
        public static string ENOV_FOLDER_B19 = "ENOV_FOLDER_B19";
        public static string ENOV_FOLDER_B24 = "ENOV_FOLDER_B24";
        public static string ENOV_ICD_B19 = "ENOV_ICD_B19";
        public static string ENOV_ICD_B24 = "ENOV_ICD_B24";
        public static string Root_CTM_Sogeti_PREPROD_ENOVIAV5 = "Root,CTM_Sogeti_PREPROD,ENOVIAV5"; // ctrl m root folder for Preprod env


        public static string DC = "DC";
        public static string EE = "EE";
        public static string PC = "PC";
        public static string MI = "MI";
        public static string ENDED_OK = "Ended OK";

        public static string MCAD_OBJ1_IMAGE = "MCAD_OBJ1_IMAGE.png";
        public static string MCAD_OBJ1_SELECT_IMAGE = "MCAD_OBJ1_SELECT_IMAGE.png";
        public static string MCAD_OBJ2_IMAGE = "MCAD_OBJ1_IMAGE.png";
        public static string MCAD_OBJ2_SELECT_IMAGE = "MCAD_OBJ2_SELECT_IMAGE.png";

        public static string MCAD_OBJ3_IMAGE = "MCAD_OBJ1_IMAGE.png";
        public static string MCAD_OBJ3_SELECT_IMAGE = "MCAD_OBJ3_SELECT_IMAGE.png";


        public static string MCAD_OBJ4_IMAGE = "MCAD_OBJ1_IMAGE.png";
        public static string MCAD_OBJ4_SELECT_IMAGE = "MCAD_OBJ4_SELECT_IMAGE.png";

        public static string NEXT_BUTTON = "NEXT_BUTTON.png";
        public static string FIND_ICON = "FIND_ICON.png";
        public static string TYPE_LABEL = "TYPE_LABEL.png";
        public static string NAME_LABEL = "NAME_LABEL.png";
        public static string REVISION_LABEL = "REVISION_LABEL.png";
        public static string OWNER_LABEL = "OWNER_LABEL.png";
        public static string VAULT_LABEL = "VAULT_LABEL.png";

        public static string REPLACE_LABEL = "REPLACE_LABEL.png";
        public static string REPLACE_OBJECTS_LABEL = "REPLACE_OBJECTS_LABEL.png";
        public static string FIND_BUTTON = "FIND_BUTTON.png";
        public static string FINISH_BUTTON = "FINISH_BUTTON.png";
        public static string ORDER_BUTTON = "ORDER_BUTTON.png";

        public static string READY_RADIOBUTTON = "READY_RADIOBUTTON.png";
        public static string SUBHARNESS_OBJE1_IMAGE = "SUBHARNESS_OBJE1_IMAGE.png";
        public static string SUBHARNESS_OBJE2_IMAGE = "SUBHARNESS_OBJE2_IMAGE.png";
        public static string SUBHARNESS_OBJE3_IMAGE = "SUBHARNESS_OBJE3_IMAGE.png";
        public static string SUBHARNESS_OBJE4_IMAGE = "SUBHARNESS_OBJE4_IMAGE.png";
        public static string SUBHARNESS_OBJE5_IMAGE = "SUBHARNESS_OBJE5_IMAGE.png";
        public static string SUBHARNESS_OBJE6_IMAGE = "SUBHARNESS_OBJE6_IMAGE.png";
        public static string SUBHARNESS_OBJE7_IMAGE = "SUBHARNESS_OBJE7_IMAGE.png";
        public static string SUBHARNESS_OBJE8_IMAGE = "SUBHARNESS_OBJE8_IMAGE.png";
        public static string SUBHARNESS_OBJE9_IMAGE = "SUBHARNESS_OBJE9_IMAGE.png";
        public static string SUBHARNESS_OBJE10_IMAGE = "SUBHARNESS_OBJE10_IMAGE.png";
        public static string SUBHARNESS_OBJE11_IMAGE = "SUBHARNESS_OBJE11_IMAGE.png";
        public static string SUBHARNESS_OBJE12_IMAGE = "SUBHARNESS_OBJE12_IMAGE.png";

        public static string REPLACE_OBJ_LABEL = "REPLACE_OBJ_LABEL.png";
        public static string SUBHARNESS_OBJ1_IMAGE = "SUBHARNESS_OBJ1_IMAGE.png";
        public static string SUBHARNESS_OBJ2_IMAGE = "SUBHARNESS_OBJ2_IMAGE.png";
        public static string SUBHARNESS_OBJ3_IMAGE = "SUBHARNESS_OBJ3_IMAGE.png";
        public static string SUBHARNESS_OBJ4_IMAGE = "SUBHARNESS_OBJ4_IMAGE.png";
        public static string SUBHARNESS_OBJ5_IMAGE = "SUBHARNESS_OBJ5_IMAGE.png";
        public static string SUBHARNESS_OBJ6_IMAGE = "SUBHARNESS_OBJ6_IMAGE.png";
        public static string SUBHARNESS_OBJ7_IMAGE = "SUBHARNESS_OBJ7_IMAGE.png";
        public static string SUBHARNESS_OBJ8_IMAGE = "SUBHARNESS_OBJ8_IMAGE.png";

        public static string SUBHARNESS_OBJT1_IMAGE = "SUBHARNESS_OBJT1_IMAGE.png";
        public static string SUBHARNESS_OBJT2_IMAGE = "SUBHARNESS_OBJT2_IMAGE.png";
        public static string SUBHARNESS_OBJT3_IMAGE = "SUBHARNESS_OBJT3_IMAGE.png";

        public static string PART_LABEL = "PART_LABEL.png";
        public static string CABLE_ROUTE_FIND_IMAGE = "CABLE_ROUTE_FIND_IMAGE.png";

        public static string CABLE_ROUTE_PART1_IMAGE = "CABLE_ROUTE_PART1_IMAGE.png";
        public static string CABLE_ROUTE_PART2_IMAGE = "CABLE_ROUTE_PART2_IMAGE.png";
        public static string CABLE_ROUTE_PART3_IMAGE = "CABLE_ROUTE_PART3_IMAGE.png";
        public static string CABLE_ROUTE_PART4_IMAGE = "CABLE_ROUTE_PART4_IMAGE.png";
        public static string CABLE_ROUTE_PART5_IMAGE = "CABLE_ROUTE_PART5_IMAGE.png";
        public static string CABLE_ROUTE_PART6_IMAGE = "CABLE_ROUTE_PART6_IMAGE.png";

        public static string BackButton = "BackButton.png";

        public static string LICENSE_DOWNAROW_IMAGE = "LICENSE_DOWNAROW_IMAGE.png";
        public static string LICENSE_EHI_IMAGE = "LICENSE_EHI_IMAGE.png";
        public static string LICENSE_ELB_IMAGE = "LICENSE_ELB_IMAGE.png";
        public static string LICENSE_EWR_IMAGE = "LICENSE_EWR_IMAGE.png";
        public static string LICENSE_GENERAL_IMAGE = "LICENSE_GENERAL_IMAGE.png";
        public static string LICENSE_SHARE_PROD_IMAGE = "LICENSE_SHARE_PROD_IMAGE.png";

        public static string READMAIL_ICON = "READMAIL_ICON.png"; // modarc ReadMail icon
        public static string SUBJECT_LABEL = "SUBJECT_LABEL.png";// modarc iconmail inbox subject field
        public static string FILTER_BUTTON = "FILTER_BUTTON.png"; // modarc iconmail inbox filter button
        public static string RE1001 = "re1001"; // modarc test review user
        public static string UNREADMAIL_IMAGE = "UNREADMAIL_IMAGE.png";
        public static string EXECUTE_RMB = "Execute_RMB.png";
        public static string PROMOTEPRF_RMB = "PromotePRF_RMB.png";
        public static string PRFAFTERSELECT_IMAGE = "PRFAfterSelect_IMAGE.png";
        public static string PRFBEFORESELECT_IMAGE = "PRFBeforeSelect_IMAGE.png";
        public static string DC1_CHECKBOX = "DC1_CHECKBOX.png";
        public static string PROMOTE_RADIOBUTTON = "Promote_RADIOBUTTON.png";
        public static string PRODUCT_DOCUMENTATION = "Product Documentation";
        public static string SEARCH_RESULT_PD_BEFORE_SELECT_IMAGE = "SEARCHRESULTPD_BEFORESELECT_IMAGE.png";
        public static string SEARCH_RESULT_PD_AFTER_SELECT_IMAGE = "SEARCHRESULTPD_AFTERSELECT_IMAGE.png";
        public static string PROPERTIES = "Properties.png";
        public static string ATTRIBUTES_ICON = "ATTRIBUTES_ICON.png";
        public static string OBJECT_MENU = "OBJECT_MENU.png";
        public static string DELETE_MENU = "DELETE_MENU.png";
        public static string MODEL_TYPE_V5_LABEL = "MODEL_TYPE_V5_LABEL.png";
        public static string FALSE = "FALSE";
        public static string CLOSE = "Close.png";
        public static string cmdRefresh = "C:Refresh";
        public static string MODIFY_BUTTON = "MODIFY_BUTTON.png";
        public static string YES_BUTTON = "YES_BUTTON.png";
        public static string GBNSysVer477 = "GBNSysVer477.png";
        public static string START_MATRIX_BUTTON = "START_MATRIX_BUTTON.png";

        public static string Infra = "Infra.png";

        //Electrical parameters
        public static string INFRA_TAB_IMAGE = "INFRA_TAB_IMAGE.png";
        public static string PART_INFRA_IMAGE = "PART_INFRA_IMAGE.png";
        public static string KEEP_LINK_IMAGE = "KEEP_LINK_IMAGE.png";
        public static string SYNC_REF_IMAGE = "SYNC_REF_IMAGE.png";
        public static string CONFIRM_LINK_IMAGE = "CONFIRM_LINK_IMAGE.png";
        public static string GBN_SYSVER_IMAGE = "GBN_SYSVER_IMAGE.png";
        public static string MB_SYSVER_IMAGE = "MB_SYSVER_IMAGE.png";

        public static string CATBRW_DWN_IMAGE = "CATBRW_DWN_IMAGE.png";
        public static string ELEC_FOLDER_IMAGE = "ELEC_FOLDER_IMAGE.png";
        public static string CONNECTOR_FOLDER_IMAGE = "CONNECTOR_FOLDER_IMAGE.png";
        public static string POL_FOLDER_IMAGE = "POL_FOLDER_IMAGE.png";
        public static string MALE_FILE_IMAGE = "MALE_FILE_IMAGE.png";
        public static string CONNECTOR_PART_IMAGE = "CONNECTOR_PART_IMAGE.png";
        public static string MAIN_WIN_DWN_IMAGE = "MAIN_WIN_DWN_IMAGE.png";
        public static string COMB_ELEC_IMAGE = "COMB_ELEC_IMAGE.png";
        public static string SUPPORT_FOLDER_IMAGE = "SUPPORT_FOLDER_IMAGE.png";
        public static string CABLETIE_FOLDER_IMAGE = "CABLETIE_FOLDER_IMAGE.png";

        public static string CABLETIE_FILE_IMAGE = "CABLETIE_FILE_IMAGE.png";
        public static string TIE_PART_IMAGE = "TIE_PART_IMAGE.png";
        public static string COMPASS_IMAGE = "COMPASS_IMAGE.png";
        public static string SNAP_PART_POPUP = "SNAP_PART_POPUP.png";
        public static string EDIT_SNAP_PART_POPUP = "EDIT_SNAP_PART_POPUP.png";
        public static string CONNECTOR_MAIN_PART_IMAGE = "CONNECTOR_MAIN_PART_IMAGE.png";
        public static string CONNECTOR_PART_SELECT_IMAGE = "CONNECTOR_PART_SELECT_IMAGE.png";
        public static string CONNECTOR_SELECT2_IMAGE = "CONNECTOR_SELECT2_IMAGE.png";
        public static string CABLE_TIE_PART_IMAGE = "CABLE_TIE_PART_IMAGE.png";
        public static string ALONG_XLABEL = "ALONG_XLABEL.png";
        public static string ALONG_YLABEL = "ALONG_YLABEL.png";

        //TAKE NEW IMAGES
        public static string MAIN_START_IMAGE = "MAIN_START_IMAGE.png";



        public static string MAIN_EQSYS_IMAGE = "MAIN_EQSYS_IMAGE.png";
        public static string ELEC_DISCIPLINE_IMAGE = "ELEC_DISCIPLINE_IMAGE.png";
        public static string ELEC_HARASM_IMAGE = "ELEC_HARASM_IMAGE.png";
        public static string ROUTE_DEF_BUTON = "ROUTE_DEF_BUTON.png";
        public static string REVERSE_TANG_BUTTON = "REVERSE_TANG_BUTTON.png";
        public static string ELEC_CONNECTOR_PART6 = "ELEC_CONNECTOR_PART6.png";
        public static string ELEC_CONNECTOR_PART5 = "ELEC_CONNECTOR_PART5.png";
        public static string ELEC_CONNECTOR_PART4 = "ELEC_CONNECTOR_PART4.png";
        public static string ELEC_CONNECTOR_PART3 = "ELEC_CONNECTOR_PART3.png";
        public static string ELEC_CONNECTOR_PART2 = "ELEC_CONNECTOR_PART2.png";

        public static string ROUT_DEFOK_BUTTON = "ROUT_DEFOK_BUTTON.png";
        public static string ROUTE_MORE_BUTTON = "ROUTE_MORE_BUTTON.png";
        public static string ROUTE_DEF_TITLE_IMAGE = "ROUTE_DEF_TITLE_IMAGE.png";

        public static string ROUTE_MOVE_TO_COMPASS = "ROUTE_MOVE_TO_COMPASS.png";


        public static string ADD_BRANCH_BUTTON = "ADD_BRANCH_BUTTON.png";

        public static string BUNDLE_SEG_BUTTON = "BUNDLE_SEG_BUTTON.png";

        public static string BUNDLE_SEG_IMAGE = "BUNDLE_SEG_IMAGE.png";

        public static string POINT_RATIO_IMAGE = "POINT_RATIO_IMAGE.png";

        public static string SPLICE_FOLDER_IMAGE = "SPLICE_FOLDER_IMAGE.png";

        public static string SPLICE_FILE_IMAGE = "SPLICE_FILE_IMAGE.png";


        public static string SPLICE_PART_IMAGE = "SPLICE_PART_IMAGE.png";

        public static string MULTI_BRANCH_PART_IMAGE = "MULTI_BRANCH_PART_IMAGE.png";

        public static string BRANCHABLE_IMAGE = "BRANCHABLE_IMAGE.png";
        public static string BUNDLE_FIRST_SEG_IMAGE = "BUNDLE_FIRST_SEG_IMAGE.png";
        public static string INTERNAL_SPLICE_IMAGE = "INTERNAL_SPLICE_IMAGE.png";
        public static string PROTECTIVE_CATALOG_IMAGE = "PROTECTIVE_CATALOG_IMAGE.png";

        public static string PROTECTIVE_COVER_IMAGE = "PROTECTIVE_COVER_IMAGE.png";


        public static string TUBE_FOLDER_IMAGE = "TUBE_FOLDER_IMAGE.png";

        public static string COGTUBE_FILE_IMAGE = "COGTUBE_FILE_IMAGE.png";

        public static string COGTUBE_PART_IMAGE = "COGTUBE_PART_IMAGE.png";


        public static string PROTECTION_COVER_PART_IMAGE = "PROTECTION_COVER_PART_IMAGE.png";


        public static string SETCOMP_CONNECTOR1_IMAGE = "SETCOMP_CONNECTOR1_IMAGE.png";
        public static string SETCOMP_CONNECTOR2_IMAGE = "SETCOMP_CONNECTOR2_IMAGE.png";
        public static string SETCOMP_CONNECTOR3_IMAGE = "SETCOMP_CONNECTOR3_IMAGE.png";
        public static string SETCOMP_CONNECTOR4_IMAGE = "SETCOMP_CONNECTOR4_IMAGE.png";
        public static string SETCOMP_CONNECTOR5_IMAGE = "SETCOMP_CONNECTOR5_IMAGE.png";
        public static string SETCOMP_CONNECTOR6_IMAGE = "SETCOMP_CONNECTOR6_IMAGE.png";
        public static string SETCOMP_CABLETIE_IMAGE = "SETCOMP_CABLETIE_IMAGE.png";
        public static string SETCOMP_PROHOST_IMAGE = "SETCOMP_PROHOST_IMAGE.png";
        public static string SETCOMP_SPLICE_IMAGE = "SETCOMP_SPLICE_IMAGE.png";



        
        
 
        //Performance

        public static string prcname = "PERF_TEST";
        public static string DocumentToSearch = "50010319-1";
        public static string ECOToSearch = "0412";
        public static string PRC = "VR";
        public static string Children = "VR-09008020";
        public static string documentadv = "1311377-1-2";
        public static string partnum = "1547075";
        public static string insertPRC = "KONAAK";
        public static string owner = "KONCCN";
        public static string despartcval = "DOOR PANEL ASSY LH*";
        public static string desdoccval = "MOUNTING PLATE DOOR LH*";

        public static string SendVPMQueryString = "c:Send To new VPM Navigator";
        public static string windowVRName = " - [VPMNav\\VR]";
        public static string windowInsertName = " - [VPMNav\\KONAAK]";
        public static string windowInsertNewName = " - [ENOVIA5\\KONAAK.CATProduct]";
        public static string testdata = "Test_InsertBS";
        public static string descdata = "*konaak*";
        public static string testinsertdata = "*Test_InsertBS*";
        public static string testbreak = "*BREAK*";
        public static string rowNumber = "1";
        public static string engWorkLayout = "1443017";
        public static string APPROVED_FOR_PRODUCTION_LABEL = "APPROVED_FOR_PRODUCTION_LABEL.png";

        public static string DTD_PRC_SYSVER_224_NAME = "DTD_PRC_SYSVER_224_NAME";
        public static string DTD_PRF_SYSVER_224_NUMBER = "DTD_PRF_SYSVER_224_NUMBER";
        public static string DTD_PRF_SYSVER_224_STATE = "DTD_PRF_SYSVER_224_STATE";
        public static string ARGUMENT_VALUE = "ARGUMENT_VALUE";
        public static string REVIEW = "REVIEW";
        public static string DELETED = "DELETED";
        public static string REVIEW_CHANGES_WITHIN_SAME_STATUS = "Review changes within same status";
        public static string SUPPORT="SUPPORT";
        public static string DESIGNER = "DESIGNER";
        public static string DTD_A_PART_SYSVER_224_NUMBER = "DTD_A_PART_SYSVER_224_NUMBER";

        //VPM Search Clear All
        public static string CLEAR_ALL_BUTTON = "CLEAR_ALL_BUTTON.png";
        public static string ARROW_DOWN_BUTTON = "ARROW_DOWN_BUTTON.png";
        public static string ROW_1865280="ROW_1865280.png";
        public static string RETURNTOREVIEW_BUTTON = "RETURNTOREVIEW_BUTTON.png";
        public static string EXCEL_PROCESS_NAME ="EXCEL";
        //public static string Sogeti_PART_TYPE_PRF = ReadDataFromFile.readInputDataByRowAndColumnName(ROW_TWO + ROW_FIVE, TD_226_20_SPARTTYPE);
        //public static string Sogeti_PART_TYPE_A = ReadDataFromFile.readInputDataByRowAndColumnName(ROW_ONE, TD_226_20_SPARTTYPE);
        //public static string CATIA_PART_TYPE_DETAIL = ReadDataFromFile.readInputDataByRowAndColumnName(ROW_ONE, TD_226_20_CPARTTYPE);
        //public static string CATIA_PART_TYPE_ASSEMBLY = ReadDataFromFile.readInputDataByRowAndColumnName(ROW_TWO, TD_226_20_CPARTTYPE);
        //public static string Sogeti_PART_TYPE_TRF = ReadDataFromFile.readInputDataByRowAndColumnName(ROW_FOUR + ROW_ONE, TD_226_20_SPARTTYPE);
        //public static string Sogeti_PART_TYPE_VR = ReadDataFromFile.readInputDataByRowAndColumnName(ROW_TWO + ROW_SEVEN, TD_226_20_SPARTTYPE);

        
    }
}
