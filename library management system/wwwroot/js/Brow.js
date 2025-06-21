//載入模組 => 預約查詢、借閱查詢
$(() => {
    console.log("已綁定事件");
    $("#AppointmentQuery").on("click", AppointmentQueryModule)
    $("#BorrowQuery").on("click", BorrowQueryModule)
})
//-----------------------------------------------
//-----------------------------------------------
// 預約查詢
// 載入綁定_預約及借閱partial
function AppointmentQueryModule() {
    initAppointmentPage();
    console.log("已載入預約查詢欄parital");
    //排列的改變
    
};
// 預約管理(搜尋欄)_初始頁載入
function initAppointmentPage() {
    $("#content-panel").load("/Home/AppointmentManagement", () => {
        query_appointMent();
        console.log("已載入預設搜尋結果");
        // 預約查詢綁定
        $("#appointment_select").on("click", query_appointMent);
        // 排列篩選綁定
        $("#appointment_perPage").on("change", appointment_perPageEvent);
        $("#appointment_state").on("change", appointment_stateEvent);
        $("#appointment_orderDate").on("change", appointment_orderDateEvent);
    });
};
// 搜尋
function query_appointMent() {
    const formData = $("#appointmenSearch").serialize();
    $.get("/Home/BookListTable", formData, (result) => {
        $("#bookTableContainer").html(result);
        $(".page-link").on("click", appointment_pagePikeEvent);
    });
    console.log("已成功查詢");
    
    // 綁定分頁按鈕
}
// 分頁
// 綁定事件 → 寫在外面，只做一次！
function appointment_pagePikeEvent() {
    const value = $(this).data("page");
    console.log(value);
}

// **排序的改變
// 1.每頁筆數
function appointment_perPageEvent() {
    let value = $("#appointment_perPage").val();
    console.log("改變每筆頁數:" + value);
}
// 2.目前狀態
function appointment_stateEvent() {
    let vaule = $("#appointment_state").val();
    console.log("目前狀態:" + vaule);
}
// 3.預約日期排序
function appointment_orderDateEvent() {
    let value = $("#appointment_orderDate").val();
    console.log("預約日期排序:" + value);
}
// END
//--------------------------------------------------------------------
//--------------------------------------------------------------------
// **施工中**
// 借閱查詢---------------------------------------"/Home/BorrowRecord"
function BorrowQueryModule() {
    alert("借閱查詢施工中");
}

