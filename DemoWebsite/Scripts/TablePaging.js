//Ensure you table rows have a attribute data-row
// 
//Ensure you have a footer like this
//<tr class="DataGridPager" nowrap="nowrap">
//    <td colspan="[number of columns]">
//        <span id="Prev">< Prev</span>
//        <a id="Prev" data-page-no="0" style="display:none">< Prev</a>
//        &nbsp;
//        <span id="Next" style="display:none">Next ></span>
//        <a id="Next" data-page-no="1">Next ></a>
//    </td>
//</tr>


//To call the binding just put some code in like this 
//      <script>
//          $(document).ready(function () {
//              BindPagingToGrid("#MyGrid");
//          });
//      </script>


//To call the binding with a specific page size
//      <script>
//          $(document).ready(function () {
//              BindPagingToGrid("#MyGrid", 8);
//          });
//      </script>

//To call the binding with a callback function for grid paging (useful for lists with extremaly large amounts of data)
// You will need an aditional element that holds the page number and doesn't refresh (like the div your data goes into)
//      <div id = "ResultsArea" data-pageno="0">
//
//      </div>
//
//      <script>
//          $(document).ready(function () {
//              BindRangePagerToGrid("#MyGrid", "#ResultsArea", CallbackFunction, @Model.RowCount);
//          });
//      </script>
//To call the binding with a callback function and page size
//      <script>
//          $(document).ready(function () {
//              BindRangePagerToGrid("#MyGrid", "#ResultsArea", 8, CallbackFunction, @Model.RowCount);
//          });
//      </script>

//Try and use Id for the gridSelector classes may run into trouble later.
function BindPagingToGrid(gridSelector) {
    BindPagingToGrid(gridSelector, undefined);
}

function BindPagingToGrid(gridSelector, pageSize) {
    if (pageSize == undefined) {
        pageSize = 10;//default size is 10
    }
    //alert(pageSize);

    showPageForGrid(0, gridSelector, pageSize);

    $(gridSelector + " a[data-page-no]").click(function () {
        showPageForGrid(parseInt($(this).attr("data-page-no")), gridSelector, pageSize);
    });
}


function showPageForGrid(pageNo, gridSelector, pageSize) {
    var rowCount = $(gridSelector + " tr[data-row]").length;
    var startIndex = pageNo * pageSize;
    var remain = rowCount - startIndex;
    var endIndex = remain > pageSize ? startIndex + pageSize - 1 : rowCount - 1;

    $(gridSelector + " tr[data-row]").hide();

    $.each($(gridSelector + " tr[data-row]"), function (i, elem) {
        if (i >= startIndex && i <= endIndex) {
            $(elem).show();
        }
    });

    var pages = Math.ceil(rowCount / pageSize) - 1; //-1 as pages start from 0
    setButtonIndexesForGrid(pageNo, gridSelector, pages);
};


function setButtonIndexesForGrid(pageNo, gridSelector, pages) {

    if (pageNo === 0) {
        $(gridSelector + " span#Prev").show();
        $(gridSelector + " a#Prev").hide();
    } else {
        $(gridSelector + " a#Prev").show();
        $(gridSelector + " a#Prev").attr("data-page-no", pageNo - 1);
        $(gridSelector + " span#Prev").hide();
    }
    if (pageNo === pages) {
        $(gridSelector + " span#Next").show();
        $(gridSelector + " a#Next").hide();
    } else {
        $(gridSelector + " a#Next").show();
        $(gridSelector + " a#Next").attr("data-page-no", pageNo + 1);
        $(gridSelector + " span#Next").hide();
    }
}

//BindChunckyPagerToGrid
function BindRangePagerToGrid(gridSelector, pageNumberSelector, loadFunction, rowCount) {
    BindRangePagerToGrid(gridSelector, pageNumberSelector, 10, loadFunction, rowCount);
}

function BindRangePagerToGrid(gridSelector, pageNumberSelector, pageSize, loadFunction, rowCount) {
    var pages = Math.ceil(rowCount / pageSize) - 1; //-1 as pages start from 0

    setButtonIndexesForGrid(parseInt($(pageNumberSelector).data("pageno")), gridSelector, pages);

    $(gridSelector + " a[data-page-no]")
        .click(function () {
            $(pageNumberSelector).data("pageno", ($(this).attr("data-page-no")));
            loadFunction(parseInt($(this).attr("data-page-no")));
        });
}
