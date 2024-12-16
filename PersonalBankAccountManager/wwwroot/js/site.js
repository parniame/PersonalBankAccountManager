// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


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

let first = true;
$(document).ready(function () {
    if (first) {
        $("#addCategory").submit();
        first = false;
    }
    $('input[type=radio]').change(function () {
        if ($('#IsWithdrawl1').is(':checked')) {
            $('#isPositive').val($('#IsWithdrawl1').val());
            $("#addCategory").submit();
        }
        if ($('#IsWithdrawl2').is(':checked')) {
            $('#isPositive').val($('#IsWithdrawl2').val())
            $("#addCategory").submit();
        }
    });
});

function SetPlanner(e) {


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
            $('#isPositive').val($('#IsWithdrawl2').val());
            $("#addCategory").submit();
            falseWithdrawlRadio.prop('disabled', true);
        }
        else {
            falseWithdrawlRadio.prop('checked', true);
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

}



function ShowDeleteModal(Id) {

    let input = $("#entityIdInput");
    console.log(input)
    input.val(Id);

    var thisModal = $("#delete-modal");
    thisModal.modal("show");

}
function ShowDetailsModal(Id) {

    let input = $("#bankAccountId");
    let input2 = $("#transactiontId");
    let input3 = $("#plannerId");
    input.val(Id);

    input2.val(Id);
    input3.val(Id);
    let form = $("#addDetails");
    form.submit();
    let thisModal = $("#details-modal");
    thisModal.modal("show");

}
function ShowDetailsModalPlan(description) {

    
    let td = $("#description");
    
    td.html(description);
    
    let thisModal = $("#details-modal");
    thisModal.modal("show");

} 


$('#addTransactionForm').on('reset', function (e) {
    console.log("hi");
    let amountInput = $("#transactionAmount");
    let falseWithdrawlRadio = $("#IsWithdrawl1");
    let trueWithdrawlRadio = $("#IsWithdrawl2");
    amountInput.prop("readonly", false);
    trueWithdrawlRadio.prop('disabled', false);
    falseWithdrawlRadio.prop('disabled', false);
});
$(".disabled").prop('disabled', true);


if ($("#transactionTable").length) {
let minDate, maxDate;

// Custom filtering function which will search data in column four between two values

let table = new DataTable('#transactionTable', {
    
   
    initComplete: function () {
        this.api()
            .columns()
            .every(function () {
                var column = this;
                var title = column.footer().textContent;

                // Create input element and add event listener
                $('<input type="text" placeholder="جستوجو ' + title + '" />')
                    .appendTo($(column.footer()).empty())
                    .on('keyup change clear', function () {
                        if (column.search() !== this.value) {
                            column.search(this.value).draw();
                        }
                    });
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

        //top1: {
        //    searchPanes: {
        //        viewTotal: true,
        //        initCollapsed: true,
                
                
        //        controls: false,
                
               
        //    }
        //}

    },
    language: {
        searchPanes: {
            clearMessage: 'پاک کردن',
            collapseMessage: 'بستن ',
            showMessage:'باز کردن',
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
        }
    ]
});

    DataTable.ext.search.push(function (settings, data, dataIndex) {
        let min = minDate.val();
        let max = maxDate.val();
        let date = new Date(data[4]);

        if (
            (min === null && max === null) ||
            (min === null && date <= max) ||
            (min <= date && max === null) ||
            (min <= date && date <= max)
        ) {
            return true;
        }
        return false;
    });

    // Create date inputs
    minDate = new DateTime('#min', {
        format: 'MMMM Do YYYY'
    });
    maxDate = new DateTime('#max', {
        format: 'MMMM Do YYYY'
    });

    // Refilter the table
    document.querySelectorAll('#min, #max').forEach((el) => {
        el.addEventListener('change', () => table.draw());
    });
    var info = table.page.info();
    $("#transactionTable_wrapper > div:nth-child(1)").prepend('<table border="0" cellspacing="5" cellpadding="5"><tbody><p>فیلتر بر اساس روز ساخت:</p><tr><td>از تاریخ</td><td><input type="text" id="min" name="min"></td></tr><tr><td>تا تاریخ</td><td><input type="text" id="max" name="max"></td></tr></tbody></table>');
}




// topStart: {
//         buttons: [
//             {
//                 extend: 'searchPanes',
//                 config: {

//                     text :"فیلتر",


//                     viewTotal: true,
//                     initCollapsed: true
//                         ,

//             delayInit: false
//                 },




//             }
//         ]
//       },

if ($("#bankAccountTable").length) {
    let table2 = new DataTable('#bankAccountTable', {



        initComplete: function () {
            this.api()
                .columns()
                .every(function () {
                    var column = this;
                    var title = column.footer().textContent;

                    // Create input element and add event listener
                    $('<input type="text" placeholder="جستوجو ' + title + '" />')
                        .appendTo($(column.footer()).empty())
                        .on('keyup change clear', function () {
                            if (column.search() !== this.value) {
                                column.search(this.value).draw();
                            }
                        });
                });
        },
        layout: {
            topStart: {
                pageLength: {
                    menu: [3, 5, 10, 25, 50, [- 1, "همه"]]
                },

            },

            //top1: {
            //    searchPanes: {
            //        viewTotal: true,
            //        initCollapsed: true,


            //        controls: false,


            //    }
            //}

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


        ]
    });
}

if ($("#PlannerTabel").length) {
    let minDate, maxDate;

    // Custom filtering function which will search data in column four between two values
    DataTable.ext.search.push(function (settings, data, dataIndex) {
        let min = minDate.val();
        let max = maxDate.val();
        let date = new Date(data[4]);

        if (
            (min === null && max === null) ||
            (min === null && date <= max) ||
            (min <= date && max === null) ||
            (min <= date && date <= max)
        ) {
            return true;
        }
        return false;
    });

    // Create date inputs
    minDate = new DateTime('#min', {
        format: 'MMMM Do YYYY'
    });
    maxDate = new DateTime('#max', {
        format: 'MMMM Do YYYY'
    });


    let table = new DataTable('#PlannerTabel', {

        initComplete: function () {

            this.api()
                .columns()
                .every(function () {
                    var column = this;
                    var title = column.footer().textContent;

                    // Create input element and add event listener
                    $('<input type="text" placeholder="جستوجو ' + title + '" />')
                        .appendTo($(column.footer()).empty())
                        .on('keyup change clear', function () {
                            if (column.search() !== this.value) {
                                column.search(this.value).draw();
                            }
                        });
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
                    menu: [3, 5, 10, 25, 50, [-1, "kk"]]
                },

                





                // buttons: [
                //     {
                //         extend: 'searchPanes',
                //         config: {

                //             text :"فیلتر",


                //             viewTotal: true,
                //             initCollapsed: true
                //                 ,


                //     delayInit: false,
                //     liveSearch: false
                //         },




                //     }
                // ]
            },

            top1: {

                //             searchPanes: {
                //                 viewTotal: true,
                //                         initCollapsed: true,

                // clear: false


                //             }
            }

        },


        columnDefs: [
            { type: 'date', targets: [4, 5] },
              
        ]
    });
    // Refilter the table
    document.querySelectorAll('#min, #max').forEach((el) => {
        el.addEventListener('change', () => table.draw());
    });
}

//$('.dt-info').html(

//    'نشان دادن' + (info.page + 1) + ' از ' + info.pages + ' صفحه'
//);
$("label[for='dt-length-0']").html(
    ' تعداد هر سطر'
);
$("label[for='dt-length']").html(
    ' تعداد هر سطر'
);
//$("label[for='dt-search-0']").html(
//    ' جستوجو'
//);
$("button.dt-button").html(
    " <span>دسته بندی ها </span>"
)