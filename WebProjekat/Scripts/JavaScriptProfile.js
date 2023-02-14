function searchNaziv() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("nazivInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("filterTabela");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
function searchTip() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("tipInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("filterTabela");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function searchFCentar() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("fitnesInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("filterTabela");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[2];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
function searchNazivTip() {
    // Declare variables
    var input1,input2, filter1,filter2, table, tr, td1, td2, i, txtValue1,txtValue2;
    input1 = document.getElementById("nazivInput");
    input2 = document.getElementById("tipInput");
    filter1 = input1.value.toUpperCase();
    filter2 = input2.value.toUpperCase();
    table = document.getElementById("filterTabela");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[0];
        td2 = tr[i].getElementsByTagName("td")[1];
        if (td1 && td2) {
            txtValue1 = td1.textContent || td1.innerText;
            txtValue2 = td2.textContent || td2.innerText;
            if ((txtValue1.toUpperCase().indexOf(filter1) > -1) && (txtValue2.toUpperCase().indexOf(filter2) > -1)) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function searchTipFintes() {
    // Declare variables
    var input1, input2, filter1,filter2, table, tr, td1, td2, i, txtValue1, txtValue2;
    input1 = document.getElementById("tipInput");
    input2 = document.getElementById("fitnesInput");
    filter1 = input1.value.toUpperCase();
    filter2 = input2.value.toUpperCase();
    table = document.getElementById("filterTabela");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[1];
        td2 = tr[i].getElementsByTagName("td")[2];
        if (td1 && td2) {
            txtValue1 = td1.textContent || td1.innerText;
            txtValue2 = td2.textContent || td2.innerText;
            if ((txtValue1.toUpperCase().indexOf(filter1) > -1) && (txtValue2.toUpperCase().indexOf(filter2) > -1)) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function searchNazivFitnes() {
    // Declare variables
    var input1, input2, filter1,filter2, table, tr, td1, td2, i, txtValue1, txtValue2;
    input1 = document.getElementById("nazivInput");
    input2 = document.getElementById("fitnesInput");
    filter1 = input1.value.toUpperCase();
    filter2 = input2.value.toUpperCase();
    table = document.getElementById("filterTabela");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[0];
        td2 = tr[i].getElementsByTagName("td")[2];
        if (td1 && td2) {
            txtValue1 = td1.textContent || td1.innerText;
            txtValue2 = td2.textContent || td2.innerText;
            if ((txtValue1.toUpperCase().indexOf(filter1) > -1) && (txtValue2.toUpperCase().indexOf(filter2) > -1)) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function searchNazivTipFitnes() {
    // Declare variables
    var input1, input2, filter1,filter2, table, tr, td1, td2, i, txtValue1, txtValue2;
    input1 = document.getElementById("nazivInput");
    input2 = document.getElementById("tipInput");
    var input3 = document.getElementById("fitnesInput");
    filter1 = input1.value.toUpperCase();
    filter2 = input2.value.toUpperCase();
    var filter3 = input3.value.toUpperCase();
    table = document.getElementById("filterTabela");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td1 = tr[i].getElementsByTagName("td")[0];
        td2 = tr[i].getElementsByTagName("td")[1];
        var td3 = tr[i].getElementsByTagName("td")[2];
        if (td1 && td2) {
            txtValue1 = td1.textContent || td1.innerText;
            txtValue2 = td2.textContent || td2.innerText;
            var txtValue3 = td3.textContent || td3.innerText;
            if ((txtValue1.toUpperCase().indexOf(filter1) > -1) && (txtValue2.toUpperCase().indexOf(filter2) > -1) && (txtValue3.toUpperCase().indexOf(filter3) > -1)) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

function Search() {

    var input1, input2, input3, filter1,filter2, table, tr, td1, td2, i, txtValue1, txtValue2;
    input1 = document.getElementById("nazivInput");
    input2 = document.getElementById("tipInput");
    input3 = document.getElementById("fitnesInput");
    filter1 = input1.value.toUpperCase();
    filter2 = input2.value.toUpperCase();
    var filter3 = input3.value.toUpperCase();

    table = document.getElementById("filterTabela");
    tr = table.getElementsByTagName("tr");

    if (filter1.length != 0 && filter2.length == 0 && filter3.length == 0)
        return searchNaziv();
    else if (filter1.length == 0 && filter2.length != 0 && filter3.length == 0)
        return searchTip();
    else if (filter1.length == 0 && filter2.length == 0 && filter3.length != 0)
        return searchFCentar();
    else if (filter1.length != 0 && filter2.length != 0 && filter3.length == 0)
        return searchNazivTip();
    else if (filter1.length != 0 && filter2.length != 0 && filter3.length != 0)
        return searchNazivTipFitnes();
    else if (filter1.length != 0 && filter2.length == 0 && filter3.length != 0)
        return searchNazivFitnes();
    else if (filter1.length == 0 && filter2.length != 0 && filter3.length != 0)
        return searchTipFintes();
    else if (filter1.length == 0 && filter2.length == 0 && filter3.length == 0) {
        for (i = 0; i < tr.length; i++)
            tr[i].style.display = "";
    }


}

