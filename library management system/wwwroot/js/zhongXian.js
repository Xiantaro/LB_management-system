// #region 載入parital => 預約查詢、借閱查詢、借書模式、還書模式、預約模式
$(() => {
    console.log("已綁定事件");
    $("#AppointmentQuery").on("click", AppointmentQueryModule)
    $("#BorrowQuery").on("click", BorrowQueryModule)
    $("#BorrowMode").on("click", BorrowModeMode)
    $("#ReturnMode").on("click", ReturnBookMode);
    $("#AppointmentMode").on("click", AppointmentMode);
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

        // 點擊按鈕
        $(".NotificationBtn").on("click", NotificationBtn);

        $("#NotificationSend").on("click", NotificationMessageSend);
        $("#NotificationClear").on("click", NotificationClearBtn);
        $("#CancelBox").on("click", NotificationClose);
    });
    console.log("查詢刷新~");
}



// #endregion 預約查詢Module "END""

// #region 借閱查詢 Module
function BorrowQueryModule() {initBorrowPage();}
// 借閱查詢(搜尋欄)_初始載入
function initBorrowPage() {
    $("#content-panel").load("/Home/BorrowQuery", () => {
        console.log("成功載入_借閱模式");
        borrow_queryEvent();
        $("#borrow_select").on("click", borrow_queryEvent);
        $(document).on("change", "#borrow_perPage,#borrow_date, #borrow_orderDate", borrow_queryEvent);
        $("#borrow_clear").on("click", () => { $("#borrowForm")[0].reset(); });
        
    })
}
// 搜尋、分頁、排列
function borrow_queryEvent() {
    let value = $(this).data("page") || 1;
    let borrowData = $("#borrowForm").serialize() + `&page=${value}`;
    $.get("/Home/BorrowResult", borrowData, (result) => {
        $("#BorrowContent").html(result);
        console.log("成功");
        $(".page-link").on("click", borrow_queryEvent);

        // 點擊按鈕
        $(".NotificationBtn").on("click", NotificationBtn);

        $("#NotificationSend").on("click", NotificationMessageSend);
        $("#NotificationClear").on("click", NotificationClearBtn);
        $("#CancelBox").on("click", NotificationClose);
    })
}
// #endregion 借閱查詢Module END

// #region 借閱模式 Module
function BorrowModeMode() {
    console.log("借書模式測試");
    $("#content-panel").load("/Home/BorrowMode", () => {
        console.log("借書載入成功");
        $("#borrowSend").on("click", BorrowModeSend);
        BorrowModeModeUserDynamic();
        BorrowModeModeBookDynamic();
        $("#borrwoMode_UserID").on("input", BorrowModeModeUserDynamic)
        $("#borrwoMode_BookNumber").on("input", BorrowModeModeBookDynamic);
        $("#borrwoMode_CancelUserIDBtn, #borrwoMode_CancelBookIdBtn").on("click", CancelBtn)
    });
}
// 動態搜尋 借閱者
function BorrowModeModeUserDynamic() {
    let userId = $("#borrwoMode_UserID").val();
    console.log("測試動態借閱者資訊: " + userId);
    $.post("/Home/BorrowUserMessage", { userId: userId }, (result) => {
        $("#BorrowModeUser").html(result);
    })
}
// 動態搜尋 書本資訊
function BorrowModeModeBookDynamic() {
    let bookId = $("#borrwoMode_BookNumber").val();
    console.log("測試動態書本資訊: " + bookId);
    $.post("/Home/BorrowBookMessage", { bookId: bookId }, (result) => {
        $("#BorrowModeBook").html(result);
    })
}
// 借閱書籍 發送POST
function BorrowModeSend() {
    let userId = $("#borrwoMode_UserID").val();
    let bookId = $("#borrwoMode_BookNumber").val();
    if (userId === "" && bookId === "") { alert("請輸入借閱者ID和書籍編號"); return;    }
    if (userId === "") { alert("請輸入借閱者ID!!"); return; }
    if (bookId === "") { alert("請輸入書籍編號!!"); return; }
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
        $("#ReturnBookBtn").on("click", ReturnBookSend);
        $("#ReturnBook_CancelBookNumBtn").on("click", CancelBtn);
    })
}

// 還書送出
function ReturnBookSend() {
    let bookId = $("#ReturnBookID").val();
    if (bookId === "") { alert("請輸入書籍編號!!"); return; }
    let data = $("#ReturnBookIdForm").serialize();
    $.post("/Home/ReturnBookSend", data, (result) => {
        $("#ReturnBookContent").html(result);
        $("#ReturnBookID").val("");
    })
}
// #endregion 還書模式 END Module

// #region 預約模式 Module
function AppointmentMode() {
    console.log("預約模式進入");
    $("#content-panel").load("/Home/AppointmentMode1", () => {
        console.log("已進入Action")
        $("#appointmentSend").on("click", AppointmentModeSend);
        $("#appointmentMode_KeyWord").on("input", AppointmentModeBookDynamic);
        $("#appointmentMode_CancelUserIdBtn ,#appointmentMode_CancelBookNumBtn").on("click", CancelBtn);
        $("#appointmentMode_CancelKeyWordBtn").on("click", CancelBtn_AppointVersion);
        $("#appointment_state, #appointment_perPage").on("change", AppointmentModeBookDynamic);
    })
} 

// 關鍵字查詢
function AppointmentModeBookDynamic() {
    let keyWord = $("#appointmentMode_KeyWord").val(); 
    let state = $("#appointment_state").val();
    let pageCount = $("#appointment_perPage").val();
    let obj = { keyWord: keyWord, state: state, pageCount: pageCount }
    console.log(`${state}與${pageCount}`);
    if (keyWord === " ") {
        alert("請不要輸入空字串");
        $("#appointmentMode_KeyWord").val("");
        return
    }
    if (keyWord === "") { $("#appointmentQueryBook").remove; $("#appointmentQueryBook").html(appointmentQueryBookHtml); return }
    $.post("/Home/AppointmentMode1Query", obj, (result) => {
        $("#appointmentQueryBook").html(result);
        console.log("成功載入書本");
        $(".AppointmentMode_AddBookNumBtn").on("click", AppointmentModeAddBook);
    });
}
// 預約按鈕發送
function AppointmentModeSend() {
    let userId = $("#appointmentMode_UserID").val();
    let BookId = $("#appointmentMode_BookNumber").val();
    if (userId === "" && BookId === "") { alert("請輸入借閱者ID和書籍編號"); return; }
    if (userId === "") { alert("請輸入借閱者ID!!"); return; }
    if (BookId === "") { alert("請輸入書籍編號!!"); return; }
    let formData = $("#appointmentModeForm").serialize();
    console.log("測試輸入: " + formData);
    $.post("/Home/AppointmentMode1Send", formData, (result) => {
        $("#appointmentSuccessContent").html(result);
        console.log("預約按鈕是否成功回傳，YEEEEEE")
    })
}
// 加入書籍編號到輸入框
function AppointmentModeAddBook() {
    let bookNumber = $(this).closest("tr").find("td").data("booknumber");
    console.log("你的書本編號: " + bookNumber )
    $("#appointmentMode_BookNumber").val(bookNumber);
}
// 關鍵字專屬清潔按鈕
function CancelBtn_AppointVersion() {
    console.log("點擊清除按鈕");
    $(this).closest(".input-group").find(".form-control").val("");
    $("#appointmentQueryBook").remove; $("#appointmentQueryBook").html(appointmentQueryBookHtml); 
}

// #endregion 預約模式 Module END

// #region 通用函數

// 按鈕清除 
function CancelBtn() {
    console.log("點擊清除按鈕")
    $(this).closest(".input-group").find(".form-control").val("");
}


// 通知&取消預約按鈕
function appointment_cancelEvent() {
    let appointmentid = $(this).closest("tr").find(".appointmentid").data("appointmentid");
    $.post("/Home/AppointmentCancel", { appointmentid: appointmentid }, (result) => {
        if (result == "") { alert(`成功取消預約，預約編號: ${appointmentid}`) }
        else { alert("預約取消失敗"); }
        appointment_queryEvent();
    })
    console.log("取消按鈕測試: " + appointmentid);
}

// 清空搜尋資料
function appointment_clearEvent() {
    $("#appointmenSearch")[0].reset();
}


// 點擊通知
function NotificationBtn() {
    let inputrer = $(this).closest("tr").find(".NotificationUserid").text();
    
    let btnType = $(this).data("type");
    if (btnType === "notification") { $("#NotificationType").val("NormalNotification"); }
    else { $("#NotificationType").val("CancelNotification"); }

    let typeinput = $("#NotificationType").val();
    $("#NotificationInput").val(typeinput);
    $("#NotificationUser").val(inputrer)
};

// 送出按鈕
function NotificationMessageSend() {
    let myform = $("#NotificationFom").serialize();
    $.post("/Home/Notification", myform, (result) => {
        if (result === "") { alert("成功送出") }
        NotificationClose();
    })
};
// 清除按鈕
function NotificationClearBtn() {
    $("#NotificationTextarea").val("");
}
// 關閉視窗
function NotificationClose() {
    console.log("關閉視窗按鈕成功")
    $('#notificationModal').modal("hide");
    $("#NotificationTextarea").val("");
}

// #endregion

// #region 可插的HTML
// 預約模式_顯示欄位
let appointmentQueryBookHtml = `<table class="table mt-2">
                    <thead>
                        <tr>
                            <th scope="col">書籍編號</th>
                            <th scope="col">書籍名稱</th>
                            <th scope="col">狀況</th>
                            <th scope="col">操作</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table><h1 class="text-danger">查無書籍</h1>`;
// #endregion