// #region 載入parital => 預約查詢、借閱查詢、借書預約模式、還書模式
$(() => {
    console.log("已綁定事件");
    $("#AppointmentQuery").on("click", AppointmentQueryModule)
    $("#BorrowQuery").on("click", BorrowQueryModule)
    $("#BorrowMode").on("click", BorrowModeMode)
    $("#ReturnMode").on("click", ReturnBookMode);
})
// #endregion

// #region 預約查詢&管理 Module
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
// 搜尋、排列、分頁
function appointment_queryEvent() {
    const value = $(this).data("page") || 1;
    let formData = $("#appointmenSearch").serialize() + `&page=${value}`;
    $.post("/Home/AppointmentResult", formData, (result) => {
        $("#AppointmentContent").html(result);
        $(".page-link").on("click", appointment_queryEvent);
        $(".appoimtmentCancelBtn").on("click", appointment_cancelEvent);
    });
    console.log("查詢刷新~");
}
// 取消預約按鈕
function appointment_cancelEvent() {
    let appointmentid = $(this).closest("tr").find(".appointmentid").data("appointmentid");
    $.post("/Home/AppointmentCancel", { appointmentid: appointmentid }, (result) => {
        if (result == "") { alert(`成功取消預約，預約編號: ${appointmentid}`)}
        else { alert("預約取消失敗"); } 
        appointment_queryEvent();
    })
    console.log("取消按鈕測試: " + appointmentid );
}

// 清空搜尋資料
function appointment_clearEvent() {$("#appointmenSearch")[0].reset();
}
// #endregion 預約查詢Module "END""

// #region 借閱查詢Module
function BorrowQueryModule() {initBorrowPage();}
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
// 搜尋、分頁、排列
function borrow_queryEvent() {
    let value = $(this).data("page") || 1;
    let borrowData = $("#borrowForm").serialize() + `&page=${value}`;
    $.get("/Home/BorrowResult", borrowData, (result) => {
        $("#BorrowContent").html(result);
        console.log("成功");
        $(".page-link").on("click", borrow_queryEvent)
    })
}
// #endregion 借閱查詢Module END

// #region 借書預約模式 Module
function BorrowModeMode() {
    console.log("借書模式測試");
    $("#content-panel").load("/Home/BorrowMode", () => {
        console.log("借書載入成功");
        $("#borrowSend, #appointmentSend").on("click", BorrowModeSend);
        BorrowModeModeUserDynamic();
        BorrowModeModeBookDynamic();
        $("#borrwoMode_UserID").on("input", BorrowModeModeUserDynamic)
        $("#borrwoMode_BookNumber").on("input", BorrowModeModeBookDynamic);
    });
}
// 動態搜尋 借閱者
function BorrowModeModeUserDynamic() {
    let userId = $("#borrwoMode_UserID").val();
    $.post("/Home/BorrowUserMessage", { userId: userId }, (result) => {
        $("#BorrowModeUser").html(result);
    })
}
// 動態搜尋 書本資訊
function BorrowModeModeBookDynamic() {
    console.log("測試書本資訊");
    let bookId = $("#borrwoMode_BookNumber").val();
    $.post("/Home/BorrowBookMessage", { bookId: bookId }, (result) => {
        $("#BorrowModeBook").html(result);
    })
}
// 借閱、預約書籍 發送POST
function BorrowModeSend() {
    let formData = $("#borrwoModeForm").serialize();
    let btnValue = $(this).val();
    if (btnValue === "borrow") {
        alert(btnValue);
        $.post("/Home/BorrowSend", formData, (result) => {
            $("#BorrowModeSuccessContent").html(result);
        })
    }
    else {
        alert(btnValue);
        $.post("/Home/AppointmentSend", formData, (result) => {
            $("#BorrowModeSuccessContent").html(result);
        })
    }
    
} 

// #endregion 借書模式 END

// #region 還書模式 Module
function ReturnBookMode() {
    $("#content-panel").load("/Home/ReturnBookMode", () => {
        $("#ReturnBookBtn").on("click", ReturnBookSend)
    })
}

// 還書送出
function ReturnBookSend() {
    let data = $("#ReturnBookIdForm").serialize();
    $.post("/Home/ReturnBookSend", data, (result) => {
        $("#ReturnBookContent").html(result);
        $("#ReturnBookID").val("");
    })
}
// #endregion 還書模式 END Module
