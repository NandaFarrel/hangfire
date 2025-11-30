using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hangfire_template.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpenProjectIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrelloBoardId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sptstock",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spt_itemnum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spt_whs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spt_type = table.Column<int>(type: "int", nullable: true),
                    spt_createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    spt_createBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spt_status = table.Column<int>(type: "int", nullable: true),
                    spt_modifDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    spt_modifBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spt_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spt_safety = table.Column<int>(type: "int", nullable: true),
                    spt_current = table.Column<int>(type: "int", nullable: true),
                    spt_reop = table.Column<int>(type: "int", nullable: true),
                    spt_max = table.Column<int>(type: "int", nullable: true),
                    spt_satuan = table.Column<int>(type: "int", nullable: true),
                    spt_loc = table.Column<int>(type: "int", nullable: true),
                    spt_picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spt_picture2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spt_picture3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spt_partpjg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spt_slow = table.Column<int>(type: "int", nullable: true),
                    spt_itemnew = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spt_remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spt_picture4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spt_picture5 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sptstock", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpenProjectStatusId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrelloListId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_sync_log",
                columns: table => new
                {
                    id_sync_log = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    card_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    checklist_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    checklist_item_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time_entry_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    work_package_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activity_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    synced_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sync_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    error_message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sync_log", x => x.id_sync_log);
                });

            migrationBuilder.CreateTable(
                name: "t_temp_listbudget",
                columns: table => new
                {
                    id_recnum_listbudget = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dim1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dim2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dim6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    budget_year = table.Column<int>(type: "int", nullable: true),
                    account_budget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description_budget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    budget_amount = table.Column<decimal>(type: "decimal(30,7)", precision: 30, scale: 7, nullable: true),
                    saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    requisition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requisition_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    requester_department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    purchase_order = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_amount = table.Column<decimal>(type: "decimal(30,7)", precision: 30, scale: 7, nullable: true),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rfq = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    insert_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    check_fire_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_temp_listbudget", x => x.id_recnum_listbudget);
                });

            migrationBuilder.CreateTable(
                name: "t_temp_listcustomer",
                columns: table => new
                {
                    id_recnum_listcustomer = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_bisnis_partner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    search_key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    language_bp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start_date_join = table.Column<DateTime>(type: "datetime2", nullable: true),
                    end_date_join = table.Column<DateTime>(type: "datetime2", nullable: true),
                    insert_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    check_fire_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_temp_listcustomer", x => x.id_recnum_listcustomer);
                });

            migrationBuilder.CreateTable(
                name: "t_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpenProjectUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrelloMemberId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "temp_dashboard_linechart_sales_order",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<int>(type: "int", nullable: true),
                    month_sort = table.Column<int>(type: "int", nullable: true),
                    month_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delivered_uninvoice = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    delivered_invoiced = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    undelivered = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    cancel_so = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    avg_value = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_temp_dashboard_linechart_sales_order", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "temp_reject_detinfor",
                columns: table => new
                {
                    id_recnum = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prno = table.Column<long>(type: "bigint", nullable: true),
                    popo = table.Column<long>(type: "bigint", nullable: true),
                    item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mitm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rdat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    qoor = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    cwar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cwoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    insert_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    crdt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_temp_reject_detinfor", x => x.id_recnum);
                });

            migrationBuilder.CreateTable(
                name: "TempListDataRejectPortal",
                columns: table => new
                {
                    prno = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    popo = table.Column<long>(type: "bigint", nullable: true),
                    item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mitm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rdat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    qoor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    cwar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cwoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    crdt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempListDataRejectPortal", x => x.prno);
                });

            migrationBuilder.CreateTable(
                name: "tlkp_user_mapping",
                columns: table => new
                {
                    mapping_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trello_user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    openproject_user_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tlkp_user_mapping", x => x.mapping_id);
                });

            migrationBuilder.CreateTable(
                name: "ttcibd0018888",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITEM = table.Column<string>(name: "T$ITEM", type: "nvarchar(max)", nullable: false),
                    TDSCA = table.Column<string>(name: "T$DSCA", type: "nvarchar(max)", nullable: false),
                    TSEAK = table.Column<string>(name: "T$SEAK", type: "nvarchar(max)", nullable: false),
                    TSEAB = table.Column<string>(name: "T$SEAB", type: "nvarchar(max)", nullable: false),
                    TEXIN = table.Column<string>(name: "T$EXIN", type: "nvarchar(max)", nullable: false),
                    TIMAG = table.Column<string>(name: "T$IMAG", type: "nvarchar(max)", nullable: false),
                    TCRDT = table.Column<DateTime>(name: "T$CRDT", type: "datetime2", nullable: true),
                    TLMDT = table.Column<DateTime>(name: "T$LMDT", type: "datetime2", nullable: true),
                    TCOOD = table.Column<string>(name: "T$COOD", type: "nvarchar(max)", nullable: false),
                    TKITM = table.Column<decimal>(name: "T$KITM", type: "decimal(18,2)", nullable: true),
                    TCITG = table.Column<string>(name: "T$CITG", type: "nvarchar(max)", nullable: false),
                    TITMT = table.Column<decimal>(name: "T$ITMT", type: "decimal(18,2)", nullable: true),
                    TOSYS = table.Column<decimal>(name: "T$OSYS", type: "decimal(18,2)", nullable: true),
                    TCUNI = table.Column<string>(name: "T$CUNI", type: "nvarchar(max)", nullable: false),
                    TUSET = table.Column<string>(name: "T$USET", type: "nvarchar(max)", nullable: false),
                    TLTCT = table.Column<decimal>(name: "T$LTCT", type: "decimal(18,2)", nullable: true),
                    TSERI = table.Column<decimal>(name: "T$SERI", type: "decimal(18,2)", nullable: true),
                    TCNFG = table.Column<decimal>(name: "T$CNFG", type: "decimal(18,2)", nullable: true),
                    TREPL = table.Column<decimal>(name: "T$REPL", type: "decimal(18,2)", nullable: true),
                    TCPRJ = table.Column<string>(name: "T$CPRJ", type: "nvarchar(max)", nullable: false),
                    TCPVA = table.Column<long>(name: "T$CPVA", type: "bigint", nullable: true),
                    TDFIT = table.Column<string>(name: "T$DFIT", type: "nvarchar(max)", nullable: false),
                    TSTOI = table.Column<int>(name: "T$STOI", type: "int", nullable: true),
                    TOPTS = table.Column<int>(name: "T$OPTS", type: "int", nullable: true),
                    TCUST = table.Column<int>(name: "T$CUST", type: "int", nullable: true),
                    TOPOL = table.Column<int>(name: "T$OPOL", type: "int", nullable: true),
                    TWPCS = table.Column<int>(name: "T$WPCS", type: "int", nullable: true),
                    TCCFG = table.Column<string>(name: "T$CCFG", type: "nvarchar(max)", nullable: false),
                    TUNEF = table.Column<int>(name: "T$UNEF", type: "int", nullable: true),
                    TICHG = table.Column<int>(name: "T$ICHG", type: "int", nullable: true),
                    TEITM = table.Column<int>(name: "T$EITM", type: "int", nullable: true),
                    TUEFS = table.Column<int>(name: "T$UEFS", type: "int", nullable: true),
                    TUMER = table.Column<int>(name: "T$UMER", type: "int", nullable: true),
                    TCHMA = table.Column<int>(name: "T$CHMA", type: "int", nullable: true),
                    TEFCO = table.Column<string>(name: "T$EFCO", type: "nvarchar(max)", nullable: false),
                    TINDT = table.Column<DateTime>(name: "T$INDT", type: "datetime2", nullable: true),
                    TEDCO = table.Column<int>(name: "T$EDCO", type: "int", nullable: true),
                    TMCOA = table.Column<int>(name: "T$MCOA", type: "int", nullable: true),
                    TSAYN = table.Column<int>(name: "T$SAYN", type: "int", nullable: true),
                    TCONT = table.Column<int>(name: "T$CONT", type: "int", nullable: true),
                    TCNTR = table.Column<string>(name: "T$CNTR", type: "nvarchar(max)", nullable: false),
                    TCPCP = table.Column<string>(name: "T$CPCP", type: "nvarchar(max)", nullable: false),
                    TCOEU = table.Column<int>(name: "T$COEU", type: "int", nullable: true),
                    TPPEG = table.Column<int>(name: "T$PPEG", type: "int", nullable: true),
                    TIPPG = table.Column<int>(name: "T$IPPG", type: "int", nullable: true),
                    TPPSS = table.Column<int>(name: "T$PPSS", type: "int", nullable: true),
                    TELCM = table.Column<int>(name: "T$ELCM", type: "int", nullable: true),
                    TELRQ = table.Column<int>(name: "T$ELRQ", type: "int", nullable: true),
                    TDPEG = table.Column<int>(name: "T$DPEG", type: "int", nullable: true),
                    TDPTP = table.Column<int>(name: "T$DPTP", type: "int", nullable: true),
                    TDPUU = table.Column<int>(name: "T$DPUU", type: "int", nullable: true),
                    TSGTC = table.Column<int>(name: "T$SGTC", type: "int", nullable: true),
                    TSRCE = table.Column<int>(name: "T$SRCE", type: "int", nullable: true),
                    TEFPR = table.Column<int>(name: "T$EFPR", type: "int", nullable: true),
                    TDSCB = table.Column<string>(name: "T$DSCB", type: "nvarchar(max)", nullable: false),
                    TDSCC = table.Column<string>(name: "T$DSCC", type: "nvarchar(max)", nullable: false),
                    TDSCD = table.Column<string>(name: "T$DSCD", type: "nvarchar(max)", nullable: false),
                    TWGHT = table.Column<decimal>(name: "T$WGHT", type: "decimal(18,2)", nullable: true),
                    TCWUN = table.Column<string>(name: "T$CWUN", type: "nvarchar(max)", nullable: false),
                    TCTYP = table.Column<string>(name: "T$CTYP", type: "nvarchar(max)", nullable: false),
                    TCPCL = table.Column<string>(name: "T$CPCL", type: "nvarchar(max)", nullable: false),
                    TCPLN = table.Column<string>(name: "T$CPLN", type: "nvarchar(max)", nullable: false),
                    TCMNF = table.Column<string>(name: "T$CMNF", type: "nvarchar(max)", nullable: false),
                    TCSEL = table.Column<string>(name: "T$CSEL", type: "nvarchar(max)", nullable: false),
                    TCSIG = table.Column<string>(name: "T$CSIG", type: "nvarchar(max)", nullable: false),
                    TRDPT = table.Column<string>(name: "T$RDPT", type: "nvarchar(max)", nullable: false),
                    TCTYO = table.Column<string>(name: "T$CTYO", type: "nvarchar(max)", nullable: false),
                    TENVC = table.Column<int>(name: "T$ENVC", type: "int", nullable: true),
                    TCEAN = table.Column<string>(name: "T$CEAN", type: "nvarchar(max)", nullable: false),
                    TCCDE = table.Column<string>(name: "T$CCDE", type: "nvarchar(max)", nullable: false),
                    TICSI = table.Column<int>(name: "T$ICSI", type: "int", nullable: true),
                    TPSIU = table.Column<int>(name: "T$PSIU", type: "int", nullable: true),
                    TSTYP = table.Column<int>(name: "T$STYP", type: "int", nullable: true),
                    TSUBC = table.Column<int>(name: "T$SUBC", type: "int", nullable: true),
                    TOKTM = table.Column<long>(name: "T$OKTM", type: "bigint", nullable: true),
                    TDPCR = table.Column<int>(name: "T$DPCR", type: "int", nullable: true),
                    TTXTA = table.Column<string>(name: "T$TXTA", type: "nvarchar(max)", nullable: false),
                    TCDF_BATP = table.Column<string>(name: "T$CDF_BATP", type: "nvarchar(max)", nullable: false),
                    TREFCNTD = table.Column<int>(name: "T$REFCNTD", type: "int", nullable: true),
                    TREFCNTU = table.Column<int>(name: "T$REFCNTU", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ttcibd0018888", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ttdpur2008888",
                columns: table => new
                {
                    INSERT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_RQNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_ORIG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REMN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RDEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_COFC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RDAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_AEMN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_ADEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_LTDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_RQST = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CONV = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_SITE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CWAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DADR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CPRJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CSPA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CACT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CSTL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CCCO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DLDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_REFA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_REFB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_LOGN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CCUR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CCON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_URGT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CNTY = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_SPAP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RCOD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_ADIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CCTY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_TXTA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CDF_DESC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CDF_LEVL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CDF_RJMR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CDF_TGLB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_CDF_WRFL = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REFCNTD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REFCNTU = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ttdpur2008888", x => x.INSERT_DATE);
                });

            migrationBuilder.CreateTable(
                name: "ttdpur2018888",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRQNO = table.Column<string>(name: "T$RQNO", type: "nvarchar(max)", nullable: false),
                    TPONO = table.Column<int>(name: "T$PONO", type: "int", nullable: true),
                    TITEM = table.Column<string>(name: "T$ITEM", type: "nvarchar(max)", nullable: false),
                    TNIDS = table.Column<string>(name: "T$NIDS", type: "nvarchar(max)", nullable: false),
                    TEFFN = table.Column<long>(name: "T$EFFN", type: "bigint", nullable: true),
                    TCRRF = table.Column<decimal>(name: "T$CRRF", type: "decimal(18,2)", nullable: true),
                    TCITT = table.Column<string>(name: "T$CITT", type: "nvarchar(max)", nullable: false),
                    TCRIT = table.Column<string>(name: "T$CRIT", type: "nvarchar(max)", nullable: false),
                    TMPNR = table.Column<string>(name: "T$MPNR", type: "nvarchar(max)", nullable: false),
                    TCMNF = table.Column<string>(name: "T$CMNF", type: "nvarchar(max)", nullable: false),
                    TMITM = table.Column<string>(name: "T$MITM", type: "nvarchar(max)", nullable: false),
                    TQOOR = table.Column<decimal>(name: "T$QOOR", type: "decimal(18,2)", nullable: true),
                    TCUQP = table.Column<string>(name: "T$CUQP", type: "nvarchar(max)", nullable: false),
                    TCVQP = table.Column<decimal>(name: "T$CVQP", type: "decimal(18,2)", nullable: true),
                    TLENG = table.Column<decimal>(name: "T$LENG", type: "decimal(18,2)", nullable: true),
                    TWIDT = table.Column<decimal>(name: "T$WIDT", type: "decimal(18,2)", nullable: true),
                    TTHIC = table.Column<decimal>(name: "T$THIC", type: "decimal(18,2)", nullable: true),
                    TOTBP = table.Column<string>(name: "T$OTBP", type: "nvarchar(max)", nullable: false),
                    TNSDS = table.Column<string>(name: "T$NSDS", type: "nvarchar(max)", nullable: false),
                    TCCON = table.Column<string>(name: "T$CCON", type: "nvarchar(max)", nullable: false),
                    TDLDT = table.Column<DateTime>(name: "T$DLDT", type: "datetime2", nullable: true),
                    TPRIC = table.Column<decimal>(name: "T$PRIC", type: "decimal(18,2)", nullable: true),
                    TCUPP = table.Column<string>(name: "T$CUPP", type: "nvarchar(max)", nullable: false),
                    TCVPP = table.Column<decimal>(name: "T$CVPP", type: "decimal(18,2)", nullable: true),
                    TOAMT = table.Column<decimal>(name: "T$OAMT", type: "decimal(18,2)", nullable: true),
                    TSITE = table.Column<string>(name: "T$SITE", type: "nvarchar(max)", nullable: false),
                    TCWAR = table.Column<string>(name: "T$CWAR", type: "nvarchar(max)", nullable: false),
                    TCADR = table.Column<string>(name: "T$CADR", type: "nvarchar(max)", nullable: false),
                    TCPRJ = table.Column<string>(name: "T$CPRJ", type: "nvarchar(max)", nullable: false),
                    TCSPA = table.Column<string>(name: "T$CSPA", type: "nvarchar(max)", nullable: false),
                    TCACT = table.Column<string>(name: "T$CACT", type: "nvarchar(max)", nullable: false),
                    TCSTL = table.Column<string>(name: "T$CSTL", type: "nvarchar(max)", nullable: false),
                    TCCCO = table.Column<string>(name: "T$CCCO", type: "nvarchar(max)", nullable: false),
                    TGLCO = table.Column<string>(name: "T$GLCO", type: "nvarchar(max)", nullable: false),
                    TREJC = table.Column<decimal>(name: "T$REJC", type: "decimal(18,2)", nullable: true),
                    TRCOD = table.Column<string>(name: "T$RCOD", type: "nvarchar(max)", nullable: false),
                    TURGT = table.Column<decimal>(name: "T$URGT", type: "decimal(18,2)", nullable: true),
                    TCNTY = table.Column<decimal>(name: "T$CNTY", type: "decimal(18,2)", nullable: true),
                    TBGXC = table.Column<decimal>(name: "T$BGXC", type: "decimal(18,2)", nullable: true),
                    TPEGD = table.Column<decimal>(name: "T$PEGD", type: "decimal(18,2)", nullable: true),
                    TADIN = table.Column<string>(name: "T$ADIN", type: "nvarchar(max)", nullable: false),
                    TCPLA = table.Column<string>(name: "T$CPLA", type: "nvarchar(max)", nullable: false),
                    TTXTA = table.Column<string>(name: "T$TXTA", type: "nvarchar(max)", nullable: false),
                    TREFCNTD = table.Column<decimal>(name: "T$REFCNTD", type: "decimal(18,2)", nullable: true),
                    TREFCNTU = table.Column<decimal>(name: "T$REFCNTU", type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ttdpur2018888", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ttdpur2028888",
                columns: table => new
                {
                    INSERT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_RQNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_PONO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_PDNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RSIT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_MNIT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_OPRO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_ROUC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RORV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_OPNO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_OPSQ = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_PCLN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_SRVO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_SRPO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_MNWO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_MNLP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_PRNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_PPON = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_SQNB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_QONO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_QPON = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_QSEQ = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REFCNTD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REFCNTU = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ttdpur2028888", x => x.INSERT_DATE);
                });

            migrationBuilder.CreateTable(
                name: "ttdpur4008888",
                columns: table => new
                {
                    INSERT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_ORNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_OTBP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_OTAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_OTCN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_SFBP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_SFAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_SFCN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_IFBP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_IFAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_IFCN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_PTBP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_PTAD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_PTCN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CORG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_COTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RAGR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CPAY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_ODAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_ODIS = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CCUR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_MCFR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RATP_1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RATP_2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RATP_3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RATF_1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RATF_2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RATF_3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RATD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_RATT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RAUR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_SITE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CWAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CADR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CCON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_PLNR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CCRS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CFRW = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CPLP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_BPPR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_BPTX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CDEC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_PTPA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DDAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_DDTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_CBRN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CREG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_REFA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_REFB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_PRNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CTRJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_COFC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_FDPT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_ODTY = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_ODNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RETR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_SORN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_COSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_AKCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CRCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CTCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_EGEN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_SBIM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_PAFT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_SBMT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_BPCL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_OAMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_COMM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_IEBP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_IAFC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_LCCL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_HDST = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_HISP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_HISM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_ADIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CHRQ = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REVN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_OPOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CRBY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CRDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_CROR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CRCL = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CRIN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CRRQ = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_LCRQ = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_ETPC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CCTY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CVYN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_TXTA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_TXTB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CRHT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CDF_DESC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CDF_LEVL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CDF_RJMR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CDF_RQNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CDF_WRFL = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REFCNTD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REFCNTU = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ttdpur4008888", x => x.INSERT_DATE);
                });

            migrationBuilder.CreateTable(
                name: "ttdpur4028888",
                columns: table => new
                {
                    INSERT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_ORNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_PONO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_SQNB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CORG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_OORN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_OPON = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_OSQN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_SORN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_SPON = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_SSEQ = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_SCSQ = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_PDNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_OPNO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_PPON = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_LSTN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_SRVO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_SRPO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_SRSQ = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_QONO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_QPON = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_QALT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_QSEQ = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_FONO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_FOPO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RQNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RQPO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_ODTY = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_ODNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RETO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RETP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RETS = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RERS = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RTYN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_MNWO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_MNLP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_MNSQ = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_INVC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REFCNTD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REFCNTU = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ttdpur4028888", x => x.INSERT_DATE);
                });

            migrationBuilder.CreateTable(
                name: "ttfbgc1208888",
                columns: table => new
                {
                    INSERT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_ACNT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM9 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DM10 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DM11 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DM12 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIMS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DSC1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DSC2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_CABG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_LTDB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CHKA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_EXBG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_TAMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_TCUR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_TPRC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_DCMP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CWOC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_BMGR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_LEVL = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_SORT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_REFCNTD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REFCNTU = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ttfbgc1208888", x => x.INSERT_DATE);
                });

            migrationBuilder.CreateTable(
                name: "ttfbgc1608888",
                columns: table => new
                {
                    INSERT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_YEAR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_BDGT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_LEVL = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_ACNT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIMS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_PERD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_BGAM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_ALAM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RLAM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_PAAM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REFCNTD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REFCNTU = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ttfbgc1608888", x => x.INSERT_DATE);
                });

            migrationBuilder.CreateTable(
                name: "ttfbgc4008888",
                columns: table => new
                {
                    INSERT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_SEQN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_DCMP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_DCIT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_DCMT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DCLN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DCRF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_YEAR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_BDGT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_LEVL = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_DSQN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_DCST = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_TRTP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RDCP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RDIT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RDCM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RDLN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RDRF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RDST = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_ACNT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIMS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DIM9 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DM10 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DM11 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DM12 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_AMNT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CCUR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DBCR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_AMBC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RBAM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_BCUR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_QNTY = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RQTY = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_UOMS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_UPRC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_EFFD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_TTAM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_NRTA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_BPID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_ITEM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_PERD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_BABT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_BAAT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_USER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RTYP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_RTDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_RATE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_BLTP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_BUYR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_ENTP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_ENID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_TETP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_TEID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DACN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DDM1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DDM2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DDM3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DDM4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DDM5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DDM6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DDM7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DDM8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DDM9 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DD10 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DD11 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DD12 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_TRST = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RSNC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_EXCP = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_DAMT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_DAIT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_LAMN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_LTTA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_LNRT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_DQTY = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_DUOM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_LQTY = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_DCDT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    T_DRTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_FTRT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_DDCR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REIN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RERE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_PCRE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_FREC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_FSHI = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_RECO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_FRCO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_INRE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CRNO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_AUTR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_CHNG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REFCNTD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    T_REFCNTU = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ttfbgc4008888", x => x.INSERT_DATE);
                });

            migrationBuilder.CreateTable(
                name: "ttxmsl4288888",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TORNO = table.Column<string>(name: "T$ORNO", type: "nvarchar(max)", nullable: false),
                    TAPBY = table.Column<string>(name: "T$APBY", type: "nvarchar(max)", nullable: false),
                    TAPDT = table.Column<DateTime>(name: "T$APDT", type: "datetime2", nullable: true),
                    TFLAG = table.Column<decimal>(name: "T$FLAG", type: "decimal(18,2)", nullable: true),
                    TSTAT = table.Column<decimal>(name: "T$STAT", type: "decimal(18,2)", nullable: true),
                    TREMK = table.Column<string>(name: "T$REMK", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ttxmsl4288888", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ttxmsl4298888",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TORNO = table.Column<string>(name: "T$ORNO", type: "nvarchar(max)", nullable: false),
                    TAPBY = table.Column<string>(name: "T$APBY", type: "nvarchar(max)", nullable: false),
                    TAPDT = table.Column<DateTime>(name: "T$APDT", type: "datetime2", nullable: true),
                    TFLAG = table.Column<decimal>(name: "T$FLAG", type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ttxmsl4298888", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "twhinh5218888",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TORNO = table.Column<string>(name: "T$ORNO", type: "nvarchar(max)", nullable: false),
                    TPONO = table.Column<int>(name: "T$PONO", type: "int", nullable: false),
                    TCWAR = table.Column<string>(name: "T$CWAR", type: "nvarchar(max)", nullable: false),
                    TLOCA = table.Column<string>(name: "T$LOCA", type: "nvarchar(max)", nullable: false),
                    TITEM = table.Column<string>(name: "T$ITEM", type: "nvarchar(max)", nullable: false),
                    TCLOT = table.Column<string>(name: "T$CLOT", type: "nvarchar(max)", nullable: false),
                    TIDAT = table.Column<DateTime>(name: "T$IDAT", type: "datetime2", nullable: true),
                    TSTUN = table.Column<string>(name: "T$STUN", type: "nvarchar(max)", nullable: false),
                    TPKDF = table.Column<string>(name: "T$PKDF", type: "nvarchar(max)", nullable: false),
                    THUID = table.Column<string>(name: "T$HUID", type: "nvarchar(max)", nullable: false),
                    THUPR = table.Column<decimal>(name: "T$HUPR", type: "decimal(18,2)", nullable: true),
                    TQSTP = table.Column<decimal>(name: "T$QSTP", type: "decimal(18,2)", nullable: true),
                    TQSTR = table.Column<decimal>(name: "T$QSTR", type: "decimal(18,2)", nullable: true),
                    TQADJ = table.Column<decimal>(name: "T$QADJ", type: "decimal(18,2)", nullable: true),
                    TQADR = table.Column<decimal>(name: "T$QADR", type: "decimal(18,2)", nullable: true),
                    TQVRC = table.Column<decimal>(name: "T$QVRC", type: "decimal(18,2)", nullable: true),
                    TQVRR = table.Column<decimal>(name: "T$QVRR", type: "decimal(18,2)", nullable: true),
                    TRJIN = table.Column<decimal>(name: "T$RJIN", type: "decimal(18,2)", nullable: true),
                    TADAT = table.Column<DateTime>(name: "T$ADAT", type: "datetime2", nullable: true),
                    TADRN = table.Column<string>(name: "T$ADRN", type: "nvarchar(max)", nullable: false),
                    TUAPR = table.Column<decimal>(name: "T$UAPR", type: "decimal(18,2)", nullable: true),
                    TADPR = table.Column<long>(name: "T$ADPR", type: "bigint", nullable: true),
                    TPRIC = table.Column<decimal>(name: "T$PRIC", type: "decimal(18,2)", nullable: true),
                    TAMNT = table.Column<decimal>(name: "T$AMNT", type: "decimal(18,2)", nullable: true),
                    TOWNS = table.Column<decimal>(name: "T$OWNS", type: "decimal(18,2)", nullable: true),
                    TOWNR = table.Column<string>(name: "T$OWNR", type: "nvarchar(max)", nullable: false),
                    TISTR = table.Column<decimal>(name: "T$ISTR", type: "decimal(18,2)", nullable: true),
                    TIFBP = table.Column<string>(name: "T$IFBP", type: "nvarchar(max)", nullable: false),
                    TIOWN = table.Column<decimal>(name: "T$IOWN", type: "decimal(18,2)", nullable: true),
                    TDPBY = table.Column<decimal>(name: "T$DPBY", type: "decimal(18,2)", nullable: true),
                    TPRCD = table.Column<decimal>(name: "T$PRCD", type: "decimal(18,2)", nullable: true),
                    TSPCN = table.Column<string>(name: "T$SPCN", type: "nvarchar(max)", nullable: false),
                    TTXTA = table.Column<string>(name: "T$TXTA", type: "nvarchar(max)", nullable: false),
                    TREFCNTD = table.Column<decimal>(name: "T$REFCNTD", type: "decimal(18,2)", nullable: true),
                    TREFCNTU = table.Column<decimal>(name: "T$REFCNTU", type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_twhinh5218888", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "twhinr1108888",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITEM = table.Column<string>(name: "T$ITEM", type: "nvarchar(max)", nullable: false),
                    TCWAR = table.Column<string>(name: "T$CWAR", type: "nvarchar(max)", nullable: false),
                    TTRDT = table.Column<DateTime>(name: "T$TRDT", type: "datetime2", nullable: true),
                    TSEQN = table.Column<long>(name: "T$SEQN", type: "bigint", nullable: true),
                    TSITE = table.Column<string>(name: "T$SITE", type: "nvarchar(max)", nullable: false),
                    TEFFN = table.Column<long>(name: "T$EFFN", type: "bigint", nullable: false),
                    TSERL = table.Column<string>(name: "T$SERL", type: "nvarchar(max)", nullable: false),
                    TCLOT = table.Column<string>(name: "T$CLOT", type: "nvarchar(max)", nullable: false),
                    TQSTK = table.Column<double>(name: "T$QSTK", type: "float", nullable: true),
                    TOCMP = table.Column<int>(name: "T$OCMP", type: "int", nullable: true),
                    TKOOR = table.Column<decimal>(name: "T$KOOR", type: "decimal(18,2)", nullable: true),
                    TKOST = table.Column<decimal>(name: "T$KOST", type: "decimal(18,2)", nullable: true),
                    TITID = table.Column<string>(name: "T$ITID", type: "nvarchar(max)", nullable: false),
                    TITSE = table.Column<long>(name: "T$ITSE", type: "bigint", nullable: true),
                    TORNO = table.Column<string>(name: "T$ORNO", type: "nvarchar(max)", nullable: false),
                    TPONO = table.Column<int>(name: "T$PONO", type: "int", nullable: true),
                    TSRNB = table.Column<int>(name: "T$SRNB", type: "int", nullable: true),
                    TBOML = table.Column<int>(name: "T$BOML", type: "int", nullable: true),
                    TDLIN = table.Column<int>(name: "T$DLIN", type: "int", nullable: true),
                    TRCNO = table.Column<string>(name: "T$RCNO", type: "nvarchar(max)", nullable: false),
                    TRCLN = table.Column<int>(name: "T$RCLN", type: "int", nullable: true),
                    TPYPS = table.Column<long>(name: "T$PYPS", type: "bigint", nullable: true),
                    TSHPM = table.Column<string>(name: "T$SHPM", type: "nvarchar(max)", nullable: false),
                    TSHPO = table.Column<int>(name: "T$SHPO", type: "int", nullable: true),
                    TBPID = table.Column<string>(name: "T$BPID", type: "nvarchar(max)", nullable: false),
                    TCPRJ = table.Column<string>(name: "T$CPRJ", type: "nvarchar(max)", nullable: false),
                    TCSPA = table.Column<string>(name: "T$CSPA", type: "nvarchar(max)", nullable: false),
                    TCACT = table.Column<string>(name: "T$CACT", type: "nvarchar(max)", nullable: false),
                    TCSTL = table.Column<string>(name: "T$CSTL", type: "nvarchar(max)", nullable: false),
                    TCCCO = table.Column<string>(name: "T$CCCO", type: "nvarchar(max)", nullable: false),
                    TPRJP = table.Column<decimal>(name: "T$PRJP", type: "decimal(18,2)", nullable: true),
                    TPRNT = table.Column<decimal>(name: "T$PRNT", type: "decimal(18,2)", nullable: false),
                    TCHAN = table.Column<string>(name: "T$CHAN", type: "nvarchar(max)", nullable: false),
                    TQHND = table.Column<double>(name: "T$QHND", type: "float", nullable: true),
                    TLOGN = table.Column<string>(name: "T$LOGN", type: "nvarchar(max)", nullable: false),
                    TCONS = table.Column<decimal>(name: "T$CONS", type: "decimal(18,2)", nullable: true),
                    TOWNS = table.Column<decimal>(name: "T$OWNS", type: "decimal(18,2)", nullable: true),
                    TOWNR = table.Column<string>(name: "T$OWNR", type: "nvarchar(max)", nullable: false),
                    TBFBP = table.Column<string>(name: "T$BFBP", type: "nvarchar(max)", nullable: false),
                    TPHTR = table.Column<decimal>(name: "T$PHTR", type: "decimal(18,2)", nullable: true),
                    TCOSV = table.Column<decimal>(name: "T$COSV", type: "decimal(18,2)", nullable: true),
                    TREJE = table.Column<decimal>(name: "T$REJE", type: "decimal(18,2)", nullable: true),
                    TRECO = table.Column<decimal>(name: "T$RECO", type: "decimal(18,2)", nullable: true),
                    TVALM = table.Column<decimal>(name: "T$VALM", type: "decimal(18,2)", nullable: true),
                    TVWVG = table.Column<decimal>(name: "T$VWVG", type: "decimal(18,2)", nullable: true),
                    TWVGR = table.Column<string>(name: "T$WVGR", type: "nvarchar(max)", nullable: false),
                    TLGDT = table.Column<DateTime>(name: "T$LGDT", type: "datetime2", nullable: true),
                    TISEQ = table.Column<int>(name: "T$ISEQ", type: "int", nullable: true),
                    TTTYP = table.Column<string>(name: "T$TTYP", type: "nvarchar(max)", nullable: false),
                    TCINV = table.Column<long>(name: "T$CINV", type: "bigint", nullable: true),
                    TINVD = table.Column<DateTime>(name: "T$INVD", type: "datetime2", nullable: true),
                    TITRD = table.Column<DateTime>(name: "T$ITRD", type: "datetime2", nullable: true),
                    TILGD = table.Column<DateTime>(name: "T$ILGD", type: "datetime2", nullable: true),
                    TSPCN = table.Column<string>(name: "T$SPCN", type: "nvarchar(max)", nullable: false),
                    TREFCNTD = table.Column<decimal>(name: "T$REFCNTD", type: "decimal(18,2)", nullable: true),
                    TREFCNTU = table.Column<decimal>(name: "T$REFCNTU", type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_twhinr1108888", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "twhwmd2158888",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TCWAR = table.Column<string>(name: "T$CWAR", type: "nvarchar(max)", nullable: false),
                    TITEM = table.Column<string>(name: "T$ITEM", type: "nvarchar(max)", nullable: false),
                    TQHND = table.Column<double>(name: "T$QHND", type: "float", nullable: true),
                    TQCHD = table.Column<double>(name: "T$QCHD", type: "float", nullable: true),
                    TQNHD = table.Column<double>(name: "T$QNHD", type: "float", nullable: true),
                    TQBLK = table.Column<double>(name: "T$QBLK", type: "float", nullable: true),
                    TQBPL = table.Column<double>(name: "T$QBPL", type: "float", nullable: true),
                    TQORD = table.Column<double>(name: "T$QORD", type: "float", nullable: true),
                    TQOOR = table.Column<double>(name: "T$QOOR", type: "float", nullable: true),
                    TQCOR = table.Column<double>(name: "T$QCOR", type: "float", nullable: true),
                    TQNOR = table.Column<double>(name: "T$QNOR", type: "float", nullable: true),
                    TQINT = table.Column<double>(name: "T$QINT", type: "float", nullable: true),
                    TQCIT = table.Column<double>(name: "T$QCIT", type: "float", nullable: true),
                    TQNIT = table.Column<double>(name: "T$QNIT", type: "float", nullable: true),
                    TQALL = table.Column<double>(name: "T$QALL", type: "float", nullable: true),
                    TQOAL = table.Column<double>(name: "T$QOAL", type: "float", nullable: true),
                    TQCAL = table.Column<double>(name: "T$QCAL", type: "float", nullable: true),
                    TQNAL = table.Column<double>(name: "T$QNAL", type: "float", nullable: true),
                    TQNBL = table.Column<double>(name: "T$QNBL", type: "float", nullable: true),
                    TQNBP = table.Column<double>(name: "T$QNBP", type: "float", nullable: true),
                    TQCOM = table.Column<double>(name: "T$QCOM", type: "float", nullable: true),
                    TQLAL = table.Column<double>(name: "T$QLAL", type: "float", nullable: true),
                    TQCPR = table.Column<double>(name: "T$QCPR", type: "float", nullable: true),
                    TQHRJ = table.Column<double>(name: "T$QHRJ", type: "float", nullable: true),
                    TQCRJ = table.Column<double>(name: "T$QCRJ", type: "float", nullable: true),
                    TQNRJ = table.Column<double>(name: "T$QNRJ", type: "float", nullable: true),
                    TLTDT = table.Column<DateTime>(name: "T$LTDT", type: "datetime2", nullable: true),
                    THSTD = table.Column<DateTime>(name: "T$HSTD", type: "datetime2", nullable: true),
                    TLSID = table.Column<DateTime>(name: "T$LSID", type: "datetime2", nullable: true),
                    TQCIS = table.Column<double>(name: "T$QCIS", type: "float", nullable: true),
                    TQHIB = table.Column<double>(name: "T$QHIB", type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_twhwmd2158888", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "t_work_package",
                columns: table => new
                {
                    id_work_package = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpenProjectWorkPackageId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    TrelloCardId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    AssigneeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastSyncedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NeedsOpSync = table.Column<bool>(type: "bit", nullable: false),
                    NeedsTrelloSync = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_work_package", x => x.id_work_package);
                    table.ForeignKey(
                        name: "FK_t_work_package_t_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "t_project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_t_work_package_t_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "t_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_t_work_package_t_user_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "t_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "t_checklist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkPackageId = table.Column<int>(type: "int", nullable: false),
                    OpenProjectChecklistId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrelloChecklistId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_checklist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_checklist_t_work_package_WorkPackageId",
                        column: x => x.WorkPackageId,
                        principalTable: "t_work_package",
                        principalColumn: "id_work_package",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkPackageId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    OpenProjectActivityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrelloActionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_comment_t_user_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "t_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_comment_t_work_package_WorkPackageId",
                        column: x => x.WorkPackageId,
                        principalTable: "t_work_package",
                        principalColumn: "id_work_package",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_time_entry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpenProjectTimeEntryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrelloActionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPackageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SpentOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_time_entry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_time_entry_t_user_UserId",
                        column: x => x.UserId,
                        principalTable: "t_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_time_entry_t_work_package_WorkPackageId",
                        column: x => x.WorkPackageId,
                        principalTable: "t_work_package",
                        principalColumn: "id_work_package",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_checklist_item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChecklistId = table.Column<int>(type: "int", nullable: false),
                    OpenProjectItemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrelloItemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_checklist_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_checklist_item_t_checklist_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "t_checklist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_checklist_WorkPackageId",
                table: "t_checklist",
                column: "WorkPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_t_checklist_item_ChecklistId",
                table: "t_checklist_item",
                column: "ChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_t_comment_AuthorId",
                table: "t_comment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_t_comment_WorkPackageId",
                table: "t_comment",
                column: "WorkPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_t_time_entry_UserId",
                table: "t_time_entry",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_t_time_entry_WorkPackageId",
                table: "t_time_entry",
                column: "WorkPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_OPWorkPackageId",
                table: "t_work_package",
                column: "OpenProjectWorkPackageId",
                unique: true,
                filter: "[OpenProjectWorkPackageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_t_work_package_AssigneeId",
                table: "t_work_package",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_t_work_package_ProjectId",
                table: "t_work_package",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_t_work_package_StatusId",
                table: "t_work_package",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TrelloCardId",
                table: "t_work_package",
                column: "TrelloCardId",
                unique: true,
                filter: "[TrelloCardId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_checklist_item");

            migrationBuilder.DropTable(
                name: "t_comment");

            migrationBuilder.DropTable(
                name: "t_sptstock");

            migrationBuilder.DropTable(
                name: "t_sync_log");

            migrationBuilder.DropTable(
                name: "t_temp_listbudget");

            migrationBuilder.DropTable(
                name: "t_temp_listcustomer");

            migrationBuilder.DropTable(
                name: "t_time_entry");

            migrationBuilder.DropTable(
                name: "temp_dashboard_linechart_sales_order");

            migrationBuilder.DropTable(
                name: "temp_reject_detinfor");

            migrationBuilder.DropTable(
                name: "TempListDataRejectPortal");

            migrationBuilder.DropTable(
                name: "tlkp_user_mapping");

            migrationBuilder.DropTable(
                name: "ttcibd0018888");

            migrationBuilder.DropTable(
                name: "ttdpur2008888");

            migrationBuilder.DropTable(
                name: "ttdpur2018888");

            migrationBuilder.DropTable(
                name: "ttdpur2028888");

            migrationBuilder.DropTable(
                name: "ttdpur4008888");

            migrationBuilder.DropTable(
                name: "ttdpur4028888");

            migrationBuilder.DropTable(
                name: "ttfbgc1208888");

            migrationBuilder.DropTable(
                name: "ttfbgc1608888");

            migrationBuilder.DropTable(
                name: "ttfbgc4008888");

            migrationBuilder.DropTable(
                name: "ttxmsl4288888");

            migrationBuilder.DropTable(
                name: "ttxmsl4298888");

            migrationBuilder.DropTable(
                name: "twhinh5218888");

            migrationBuilder.DropTable(
                name: "twhinr1108888");

            migrationBuilder.DropTable(
                name: "twhwmd2158888");

            migrationBuilder.DropTable(
                name: "t_checklist");

            migrationBuilder.DropTable(
                name: "t_work_package");

            migrationBuilder.DropTable(
                name: "t_project");

            migrationBuilder.DropTable(
                name: "t_status");

            migrationBuilder.DropTable(
                name: "t_user");
        }
    }
}
