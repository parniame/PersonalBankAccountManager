function GetTransactionLists() {
    const resp = [];
    $.ajax({
        type: "Get",
        url: '/Transaction/GetTransactionLineChart',
        contentType: "application/json",
        async: false,
        success: function (data) {
            resp.push(data);
        },
        error: function (req, status, error) {
            // do something with error
            alert("error");
        }
    });

    return resp;

}
function GetCountCategoryLists() {
    const resp = [];
    $.ajax({
        type: "Get",
        url: '/Transaction/GetTransactionPieChart',
        contentType: "application/json",
        async: false,
        success: function (data) {
            resp.push(data);
        },
        error: function (req, status, error) {
            // do something with error
            alert("error");
        }
    });

    return resp;

}
function GetCountTransactionValues() {
    const resp = [];
    $.ajax({
        type: "Get",
        url: '/Transaction/GetTransactionBarChart',
        contentType: "application/json",
        async: false,
        success: function (data) {
            resp.push(data);
        },
        error: function (req, status, error) {
            // do something with error
            alert("error");
        }
    });

    return resp;

}

document.addEventListener("DOMContentLoaded", () => {

    const transactionLists = GetTransactionLists();
    if (transactionLists.length) {
        console.log(transactionLists);
        new Chart(document.querySelector('#lineChart'), {
            type: 'line',
            data: {
                labels: transactionLists[0].times,
                datasets: [{
                    label: 'مبلغ ها',
                    data: transactionLists[0].amounts,
                    fill: false,
                    borderColor: 'rgb(75, 192, 192)',
                    tension: 0.1
                }]
            },
            options: {
                scales: {
                    y: {
                        min: -1000,
                        max: 1000
                    }
                    //yAxes: [{
                    //    min: 0,
                    //    //max: 1000

                    //    //ticks: {


                    //    //}
                    //}]
                }
            }
        });
    }

    const categoryList = GetCountCategoryLists();
    if (categoryList.length) {
        console.log(categoryList);
        new Chart(document.querySelector('#pieChart1'), {
            type: 'pie',
            data: {
                labels: categoryList[0].categories[0],
                datasets: [{
                    label: ' تراکنش برداشت',
                    data: categoryList[0].counts[0],
                    backgroundColor: [
                        'rgb(255, 99, 132)',
                        'rgb(54, 162, 235)',
                        'rgb(255, 205, 86)'
                    ],
                    hoverOffset: 4
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        position: 'top',
                    },
                    title: {
                        display: true,
                        text: 'برداشتی'
                    }
                },

            }
        });
        new Chart(document.querySelector('#pieChart2'), {
            type: 'pie',
            data: {
                labels: categoryList[0].categories[1],
                datasets: [{
                    label: ' تراکنش واریز',
                    data: categoryList[0].counts[1],
                    backgroundColor: [
                        'rgb(255, 99, 132)',
                        'rgb(54, 162, 235)',
                        'rgb(255, 205, 86)'
                    ],
                    hoverOffset: 4
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        position: 'top',
                    },
                    title: {
                        display: true,
                        text: 'واریزی'
                    }
                },
                
            }
        });

    }
    const compare = GetCountTransactionValues();

    if (compare.length) {
        console.log(compare);
        console.log([compare[0].countAmountOut, compare[0].countAmountIn, compare[0].countAll]);
        console.log([compare[0].amountOut, compare[0].amountIn, compare[0].totalAmount]);
        new Chart(document.querySelector('#barChart1'), {
            type: 'bar',
            data: {
                labels: ['برداشتی', 'واریزی', 'درکل'],
                datasets: [
                    {
                        label: 'تعداد تراکنش  ',
                        data: [compare[0].countAmountOut, compare[0].countAmountIn, compare[0].countAll],
                        backgroundColor: 'rgba(255, 99, 132, 0.2)'
                        //[
                        //    'rgba(255, 99, 132, 0.2)',
                        //    'rgba(255, 159, 64, 0.2)',
                        //    'rgba(255, 205, 86, 0.2)',

                        //]
                        ,
                        borderColor: 'rgba(255, 99, 132)'
                            //[
                            //'rgb(255, 99, 132)',
                            //'rgb(255, 159, 64)',
                            //'rgb(255, 205, 86)',


                            //]
                        ,
                        borderWidth: 1
                    },
                    
                ],

            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        position: 'top',
                    },
                    title: {
                        display: true,
                        text: 'تعداد'
                    }
                },
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
        new Chart(document.querySelector('#barChart2'), {
            type: 'bar',
            data: {
                labels: ['برداشتی', 'واریزی', 'درکل'],
                datasets: [
                    {
                        label: 'مبلغ تراکنش  ',
                        data: [compare[0].amountOut, compare[0].amountIn, compare[0].totalAmount],
                        backgroundColor: 'rgba(255, 159, 64, 0.2)'
                        //[
                        //'rgba(255, 99, 132, 0.2)',
                        //'rgba(255, 159, 64, 0.2)',
                        //'rgba(255, 205, 86, 0.2)',

                        //]
                        ,
                        borderColor: 'rgba(255, 159, 64)'
                        //[
                        //'rgb(255, 99, 132)',
                        //'rgb(255, 159, 64)',
                        //'rgb(255, 205, 86)',


                        //]
                        ,
                        borderWidth: 1
                    },

                ],

            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        position: 'top',
                    },
                    title: {
                        display: true,
                        text: 'مبلغ'
                    }
                },
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    }





});
