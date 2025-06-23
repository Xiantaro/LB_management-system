//載入模組 => 預約查詢、借閱查詢
$(() => {
    console.log("已綁定事件");
    $("#AppointmentQuery").on("click", AppointmentQueryModule)
    $("#BorrowQuery").on("click", BorrowQueryModule)
    $("#BorrowMode").on("click", BorrowModeModule )
})
//-----------------------------------------------
//-----------------------------------------------
// 預約查詢Module  "START""
// 載入綁定_預約及借閱partial
function AppointmentQueryModule() {
    initAppointmentPage();
    console.log("已載入預約查詢欄parital");
    //排列的改變
    
};
// 預約管理(搜尋欄)_初始頁載入
function initAppointmentPage() {
    $("#content-panel").load("/Home/AppointmentQuery", () => {
        appointment_queryEvent();
        console.log("已載入預設搜尋結果");
        // 預約查詢綁定
        $("#appointment_select").on("click", appointment_queryEvent);
        // 排列篩選綁定
        $(document).on("change", "#appointment_perPage, #appointment_orderDate ", appointment_queryEvent)
        $("#appointment_clear").on("click", appointment_clearEvent);
    });
};
// 搜尋
function appointment_queryEvent() {
    const currentQuery = $("#appointmenSearch").serialize();
    $.get("/Home/AppointmentResult", currentQuery, (result) => {
        $("#AppointmentContent").html(result);
        $(".page-link").on("click", appointment_pagePikeEvent);
    });
    console.log("已成功查詢");
    //$("#appointmenSearch")[0].reset();
}
// 分頁
function appointment_pagePikeEvent() {
    const value = $(this).data("page");
    console.log(value);
}
// 清空搜尋資料
function appointment_clearEvent() {
    $("#appointmenSearch")[0].reset();
}
// 預約查詢Module "END""
//--------------------------------------------------------------------
//--------------------------------------------------------------------
// **施工中**
// 借閱查詢Module START
function BorrowQueryModule() {
    initBorrowPage();
    console.log("借閱查詢施工開始");
}
// 借閱查詢(搜尋欄)_初始載入
function initBorrowPage() {
    $("#content-panel").load("/Home/BorrowQuery", () => {
        console.log("成功載入");
        borrow_queryEvent();
        $("#borrow_select").on("click", borrow_queryEvent);
        $(document).on("change", "#borrow_perPage,#borrow_date, #borrow_orderDate", borrow_queryEvent)
        $("#borrow_clear").on("click", () => { $("#borrowForm")[0].reset(); })
    })
}
// 搜尋
function borrow_queryEvent() {
    console.log("搜尋開始");
    const borrowData = $("#borrowForm").serialize();
    $.get("/Home/BorrowResult", borrowData, (result) => {
        $("#BorrowContent").html(result);
        console.log("成功");
        $(".page-link").on("click", borrow_pagePikeEvent)
    })
}
// 分頁
function borrow_pagePikeEvent() {
    const value = $(".page-link").data("page");
    console.log("現在的值" + value);
}
// 借閱查詢Module END
//--------------------------------------------------------------------
//--------------------------------------------------------------------
// 借書 partialview
function BorrowModeModule() {
    console.log("借書模式測試");
    $("#content-panel").load("/Home/BorrowMode", () => {
        console.log("借書載入成功");
        $("#borrowSend").on("click", () => {
            alert("送出成功")
        })
    });
}

