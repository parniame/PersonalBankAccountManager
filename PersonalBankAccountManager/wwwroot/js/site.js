
// Keep file or not in transaction update
$('#fileForm input').on('change', function () {
   
    const value = $('input[name=KeepFile]:checked', '#fileForm').val();
    if (value == 'False') {
        $("#updateTransactionFileNotKeep").show();
        $("#fileForm #img").hide();
    }
    else {
        $("#updateTransactionFileNotKeep").hide();
        $("#fileForm #img").show();
    }
});
/*make disable for update*/
$(".disabled").prop('readonly', true);
$("select.disabled").prop('disabled', true);
/*radio be disabled for update and the choosen one in model be checked*/
$('.disabled:radio:not(:checked)').prop('disabled', true);
//Show transactionPlan's transaction details/show file option in update transaction
function showHideRow() {
    $(".hidden_row").toggle();
}
//make datetime cells in tables ltr!
$(".ltr").attr("dir", "ltr");
//show messages
$(document).ready(function () {
    let errorToast = document.getElementById('error-toast');
    if (!!errorToast) {
        let toastBlock = new bootstrap.Toast(errorToast);
        toastBlock.show();
    }

    let successToast = document.getElementById('success-toast');
    if (!!successToast) {
        let toastBlock = new bootstrap.Toast(successToast);
        toastBlock.show();
    }
})
//get categories in   Addtransaction 
let first1 = true;
$(document).ready(function () {
    if (first1) {
        $("#addCategory").submit();
        first1 = false;
    }
    //better code
    $('#iswithdrawlForm input').on('change', function () {
        $('#isPositive').val($('input[name=IsWithdrawl]:checked', '#iswithdrawlForm').val());
        $("#addCategory").submit();
    });
    //old code
    //$('input[name=IsWithdrawl]').change(function () {
        
        //if ($('#IsWithdrawl1').is(':checked')) {
        //    $('#isPositive').val($('#IsWithdrawl1').val());
        //    $("#addCategory").submit();
        //}
        //if ($('#IsWithdrawl2').is(':checked')) {
        //    $('#isPositive').val($('#IsWithdrawl2').val())
        //    $("#addCategory").submit();
        //}
    //});
});

//select planner in  addTransaction 
function SetPlanner(e) {

    let plannerId = $('select#transactionPlan').val();



    let overdueId = "#" + plannerId + "-isOverdue";
    let isOverdue = $(overdueId).val();
    if (isOverdue) {
        var thisModal = $("#setter-modal");
        thisModal.modal("show");
    }
    else {
        select();
    }




}
function select() {
    let plannerId = $('select#transactionPlan').val();
    let amountInput = $("#transactionAmount");
    let falseWithdrawlRadio = $("#IsWithdrawl1");
    let trueWithdrawlRadio = $("#IsWithdrawl2");
    if (plannerId) {
        let amountId = "#" + plannerId + "-transactionPlanAmout";
        let plannerAmount = $(amountId).val();
        amountInput.val(plannerAmount);
        amountInput.prop("readonly", true);

        let withdrawlId = "#" + plannerId + "-transactionPlanIsWithdrawl";
        let plannerWithdrawl = $(withdrawlId).val();
        if (plannerWithdrawl) {
            trueWithdrawlRadio.prop('checked', true);
            trueWithdrawlRadio.prop('disabled', false);
            $('#isPositive').val($('#IsWithdrawl2').val());
            $("#addCategory").submit();
            falseWithdrawlRadio.prop('disabled', true);
        }
        else {
            falseWithdrawlRadio.prop('checked', true);
            falseWithdrawlRadio.prop('disabled', false);
            $('#isPositive').val($('#IsWithdrawl1').val());
            $("#addCategory").submit();
            trueWithdrawlRadio.prop('disabled', true);
        }

    }
    else {
        amountInput.prop("readonly", false);
        trueWithdrawlRadio.prop('disabled', false);
        falseWithdrawlRadio.prop('disabled', false);
    }
    console.log($("option:selected")[0])
    $("#optionDefault").selected = false;
    console.log($("option:selected")[0])
    console.log($("option:selected"))
    var thisModal = $("#setter-modal");
    thisModal.modal("hide");

}
function deSelect() {

    $("#optionDefault").prop("selected", true);
}



function ShowDeleteModal(Id) {

    let input = $("#entityIdInput");
    console.log(input)
    input.val(Id);

    var thisModal = $("#delete-modal");
    thisModal.modal("show");

}
function ShowDetailsModal(Id, isPaid) {

    let input = $("#bankAccountId");
    let input2 = $("#transactiontId");
    let input3 = $("#plannerId");
    input.val(Id);
    input2.val(Id);
    input3.val(Id);
    let form = $("#addDetails");
    form.submit();
    if (isPaid == 'True') {

        $(".detailButton").show();
    }
    else {
        $(".detailButton").hide();
    }
    let thisModal = $("#details-modal");
    thisModal.modal("show");


}



if ($("#transactionTable").length) {


    // Custom filtering function which will search data in column four between two values

    let table = new DataTable('#transactionTable', {


        initComplete: function () {
            this.api()
                .columns()
                .every(function () {
                    var column = this;
                    var title = column.footer().textContent;
                    if (title != "اعمال") {
                        // Create input element and add event listener
                        $('<input type="text" placeholder="جستوجو ' + title + '" />')
                            .appendTo($(column.footer()).empty())
                            .on('keyup change clear', function () {
                                if (column.search() !== this.value) {
                                    column.search(this.value).draw();
                                }
                            });
                    }
                });
        },
        layout: {
            topStart: {
                pageLength: {
                    menu: [3, 5, 10, 25, 50, [- 1, "همه"]]
                },

                buttons: [
                    {
                        extend: 'searchPanes',
                        config: {

                            text: "فیلتر",


                            viewTotal: true,
                            initCollapsed: true
                            ,

                            delayInit: false
                        },
                    }
                ]
            },

        },
        language: {
            searchPanes: {
                clearMessage: 'پاک کردن',
                collapseMessage: 'بستن ',
                showMessage: 'باز کردن',
                emptyPanes: 'سطری یافت نشد :/',
                title: {
                    _: 'فیلتر انتخاب شده -%d',
                    0: 'فیلتری انتخاب نشده',
                    1: 'یک فلیتر انتخاب شده'
                },


            },
            "info": "نشان دادن _START_تا _END_ از _TOTAL_ سطر",
            "search": "جستوجو:",
            "zeroRecords": "هیچ سطری یافت نشد",
            "length": "سطر در صفحه",

        },



        columnDefs: [
            { type: 'date', targets: [4, 5] },
            {
                searchPanes: {
                    show: true,
                    header: 'فیلتر بر اساس دسته بندی تراکنش',


                },
                targets: [3]
            },
            {
                searchPanes: {
                    show: true,
                    header: 'فیلتر براساس حساب بانکی',


                },
                targets: [1]
            },
            {
                searchPanes: {
                    show: false,



                },
                targets: [2]
            },

            { orderable: false, targets: -1 }
        ]
    });
}

if ($("#bankAccountTable").length) {
    let table2 = new DataTable('#bankAccountTable', {
        initComplete: function () {
            this.api()
                .columns()
                .every(function () {
                    var column = this;
                    var title = column.footer().textContent;
                    if (title != "اعمال") {
                        // Create input element and add event listener
                        $('<input type="text" placeholder="جستوجو ' + title + '" />')
                            .appendTo($(column.footer()).empty())
                            .on('keyup change clear', function () {
                                if (column.search() !== this.value) {
                                    column.search(this.value).draw();
                                }
                            });
                    }
                });
        },
        layout: {
            topStart: {
                pageLength: {
                    menu: [3, 5, 10, 25, 50, [- 1, "همه"]]
                },

            },



        },
        language: {
            searchPanes: {
                clearMessage: 'پاک کردن',
                collapseMessage: 'بستن ',
                showMessage: 'باز کردن',
                emptyPanes: 'سطری یافت نشد :/',
                title: {
                    _: 'فیلتر انتخاب شده -%d',
                    0: 'فیلتری انتخاب نشده',
                    1: 'یک فلیتر انتخاب شده'
                },


            },
            "info": "نشان دادن _START_تا _END_ از _TOTAL_ سطر",
            "search": "جستوجو:",
            "zeroRecords": "هیچ سطری یافت نشد",
            "length": "سطر در صفحه",

        },



        columnDefs: [
            { type: 'date', targets: [2, 3] },
            

            { orderable: false, targets: -1 }


        ]
    });
}

if ($("#PlannerTabel").length) {
    let table = new DataTable('#PlannerTabel', {
        initComplete: function () {

            this.api()
                .columns()
                .every(function () {
                    var column = this;
                    var title = column.footer().textContent;
                    if (title != "اعمال") {
                        // Create input element and add event listener
                        $('<input type="text" placeholder="جستوجو ' + title + '" />')
                            .appendTo($(column.footer()).empty())
                            .on('keyup change clear', function () {
                                if (column.search() !== this.value) {
                                    column.search(this.value).draw();
                                }
                            });
                    }
                });
        },
        language: {
            searchBuilder: {
                conditions: {
                    string: {
                        contains: 'v',
                        empty: 'Empyty',
                        endsWith: 'Enbbds With',
                        equals: 'Equals',
                        not: 'cc',
                        notContains: 'Does Not Contain',
                        notEmpty: 'Not Empty',
                        notEndsWith: 'Does Not End With',
                        notStartsWith: 'Does Not Start With',
                        startsWith: 'Starts With'
                    }
                },
                valueJoiner: 'و',
                deleteTitle: 'پاک کردن',
                value: 'مقدار',
                data: 'ستون',
                condition: 'شرط ها',
                title: "فیلتر ها",
                clearAll: "پاک کردن همه",
                add: "اضافه کردن شرط",
                logic: ",",
            },
            searchPanes: {
                clearMessage: 'پاک کردن',
                collapseMessage: 'بستن ',
                showMessage: 'باز کردن',
                emptyPanes: 'سطری یافت نشد :/',
                title: {
                    _: 'فیلتر انتخاب شده -%d',
                    0: 'فیلتری انتخاب نشده',
                    1: 'یک فلیتر انتخاب شده'
                },
            },
            "info": "نشان دادن _START_تا _END_ از _TOTAL_ سطر",
            "search": "جستوجو:",
            "zeroRecords": "هیچ سطری یافت نشد",
            "length": "سطر در صفحه",

        },
        layout: {
            topStart: {
                pageLength: {
                    menu: [3, 5, 10, 25, 50, [-1, "همه"]]
                },
                buttons: [
                    {
                        extend: 'searchPanes',
                        config: {
                            text: "فیلتر ",
                            viewTotal: true,
                            initCollapsed: true
                            ,
                            delayInit: false
                        },
                    }
                ]
            },
            top1: {

            }
        },
        columnDefs: [
            { type: 'date', targets: [3, 4, 5] },
            {
                searchPanes: {
                    show: true,
                    header: 'فیلتر وضعیت',
                },
                targets: [1]
            },
            {
                searchPanes: {
                    show: false,

                },
                targets: [0, 2, 4, 5, 6]
            },
            {
                searchPanes: {
                    show: true,
                    header: 'فیلتر نوع تراکنش',
                },
                targets: [3]
            },

            { orderable: false, targets: -1 }


        ],
    });

}
if ($(".adminTable").length) {


    // Custom filtering function which will search data in column four between two values

    let table = new DataTable('.adminTable', {


        initComplete: function () {
            this.api()
                .columns()
                .every(function () {
                    var column = this;
                    var title = column.footer().textContent;
                    if (title != "اعمال") {
                        // Create input element and add event listener
                        $('<input type="text" placeholder="جستوجو ' + title + '" />')
                            .appendTo($(column.footer()).empty())
                            .on('keyup change clear', function () {
                                if (column.search() !== this.value) {
                                    column.search(this.value).draw();
                                }
                            });
                    }

                   
                });
        },
        layout: {
            topStart: {
                pageLength: {
                    menu: [3, 5, 10, 25, 50, [- 1, "همه"]]
                },

                
            },

        },
        language: {
            searchPanes: {
                clearMessage: 'پاک کردن',
                collapseMessage: 'بستن ',
                showMessage: 'باز کردن',
                emptyPanes: 'سطری یافت نشد :/',
                title: {
                    _: 'فیلتر انتخاب شده -%d',
                    0: 'فیلتری انتخاب نشده',
                    1: 'یک فلیتر انتخاب شده'
                },


            },
            "info": "نشان دادن _START_تا _END_ از _TOTAL_ سطر",
            "search": "جستوجو:",
            "zeroRecords": "هیچ سطری یافت نشد",
            "length": "سطر در صفحه",

        },



        columnDefs: [
            { type: 'date', targets: [4, 5] },

            { orderable: false, targets: -1 }
            
        ]
    });
}


$("label[for='dt-length-0']").html(
    ' تعداد هر سطر'
);
$("label[for='dt-length']").html(
    ' تعداد هر سطر'
);
$(".dt-button").html(
    " <span>دسته بندی ها </span>"
)


