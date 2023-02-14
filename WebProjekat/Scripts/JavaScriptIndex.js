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
function searchAdresa() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("adresaInput");
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
function searchGodina() {

    var inputFrom, inputTo, filter, filter2, table, tr, td, i, godina, uslov;

    inputFrom = document.getElementById("godinaInputFrom");
    inputTo = document.getElementById("godinaInputTo");

    filter = inputFrom.value;
    filter2 = inputTo.value;

    table = document.getElementById("filterTabela");
    tr = table.getElementsByTagName("tr");

    if ((filter === null || filter === "") && (filter2 === null || filter2 === "")) {
        alert("MOLIMO UNESITE BAR JEDAN BROJ ZA PRETRAGU");
    }

    else if (filter === null || filter === "") {
        for (i = 0; i < tr.length; i++) {
            td = tr[i].getElementsByTagName("td")[2];
            if (td) {
                godina = td.textContent || td.innerText;
                if (parseInt(godina) <= filter2) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }

    }

    else if (filter2 === null || filter2 === "") {
        for (i = 0; i < tr.length; i++) {
            td = tr[i].getElementsByTagName("td")[2];
            if (td) {
                godina = td.textContent || td.innerText;
                if (parseInt(godina) >= filter) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }


    else {
        for (i = 0; i < tr.length; i++) {
            td = tr[i].getElementsByTagName("td")[2];
            if (td) {
                godina = td.textContent || td.innerText;
                if ((parseInt(godina) >= filter) && (parseInt(godina) <= filter2)) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }

}


function Search() {

    var input1, input2, input3, input4, filter1, filter2, filter3, filter4, table, tr, td1, td2, i, txtValue1, txtValue2;

    input1 = document.getElementById("nazivInput");
    filter1 = input1.value.toUpperCase();

    input2 = document.getElementById("adresaInput");
    filter2 = input2.value.toUpperCase();

    input3 = document.getElementById("godinaInputFrom");
    filter3 = input3.value.toUpperCase();

    input4 = document.getElementById("godinaInputTo");
    filter4 = input4.value.toUpperCase();

    table = document.getElementById("filterTabela");
    tr = table.getElementsByTagName("tr");

    if ((filter1.length == 0) && (filter2.length == 0) && (filter3.length == 0) && (filter4.length == 0)) {
        for (i = 0; i < tr.length; i++) {
            tr[i].style.display = "";
        }
    }

    else if ((filter1.length == 0) && (filter2.length == 0) && ((filter3.length !== 0) || (filter4.length !== 0))) {
        return searchGodina();
    }
    else if ((filter1.length != 0) && (filter2.length == 0) && ((filter3.length == 0) && (filter4.length == 0))) {
        return searchNaziv();
    }
    else if ((filter1.length == 0) && (filter2.length != 0) && ((filter3.length == 0) && (filter4.length == 0))) {
        return searchAdresa();
    }
    else if ((filter1.length != 0) && (filter2.length != 0) && ((filter3.length == 0) && (filter4.length == 0))) {
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
    else if ((filter1.length != 0) && (filter2.length == 0) && (filter3.length != 0) && (filter4.length != 0)) {
        for (i = 0; i < tr.length; i++) {
            td1 = tr[i].getElementsByTagName("td")[0];
            td2 = tr[i].getElementsByTagName("td")[2];

            if (td1 && td2) {
                txtValue1 = td1.textContent || td1.innerText;
                txtValue2 = td2.textContent || td2.innerText;
                if ((txtValue1.toUpperCase().indexOf(filter1) > -1) && (parseInt(txtValue2) >= filter3) && (parseInt(txtValue2) <= filter4)) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }
    else if ((filter1.length != 0) && (filter2.length == 0) && ((filter3.length != 0) && (filter4.length == 0))) {
        for (i = 0; i < tr.length; i++) {
            td1 = tr[i].getElementsByTagName("td")[0];
            td2 = tr[i].getElementsByTagName("td")[2];

            if (td1 && td2) {
                txtValue1 = td1.textContent || td1.innerText;
                txtValue2 = td2.textContent || td2.innerText;
                if ((txtValue1.toUpperCase().indexOf(filter1) > -1) && (parseInt(txtValue2) >= filter3)) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }
    else if ((filter1.length != 0) && (filter2.length == 0) && ((filter3.length == 0) && (filter4.length != 0))) {
        for (i = 0; i < tr.length; i++) {
            td1 = tr[i].getElementsByTagName("td")[0];
            td2 = tr[i].getElementsByTagName("td")[2];

            if (td1 && td2) {
                txtValue1 = td1.textContent || td1.innerText;
                txtValue2 = td2.textContent || td2.innerText;
                if ((txtValue1.toUpperCase().indexOf(filter1) > -1) && (parseInt(txtValue2) <= filter4)) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }
    else if ((filter1.length == 0) && (filter2.length != 0) && ((filter3.length != 0) && (filter4.length != 0))) {
        for (i = 0; i < tr.length; i++) {
            td1 = tr[i].getElementsByTagName("td")[1];
            td2 = tr[i].getElementsByTagName("td")[2];

            if (td1 && td2) {
                txtValue1 = td1.textContent || td1.innerText;
                txtValue2 = td2.textContent || td2.innerText;
                if ((txtValue1.toUpperCase().indexOf(filter2) > -1) && (parseInt(txtValue2) >= filter3) && (parseInt(txtValue2) <= filter4)) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }
    else if ((filter1.length == 0) && (filter2.length != 0) && ((filter3.length != 0) && (filter4.length == 0))) {
        for (i = 0; i < tr.length; i++) {
            td1 = tr[i].getElementsByTagName("td")[1];
            td2 = tr[i].getElementsByTagName("td")[2];

            if (td1 && td2) {
                txtValue1 = td1.textContent || td1.innerText;
                txtValue2 = td2.textContent || td2.innerText;
                if ((txtValue1.toUpperCase().indexOf(filter2) > -1) && (parseInt(txtValue2) >= filter3)) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }
    else if ((filter1.length == 0) && (filter2.length != 0) && ((filter3.length == 0) && (filter4.length != 0))) {
        for (i = 0; i < tr.length; i++) {
            td1 = tr[i].getElementsByTagName("td")[1];
            td2 = tr[i].getElementsByTagName("td")[2];

            if (td1 && td2) {
                txtValue1 = td1.textContent || td1.innerText;
                txtValue2 = td2.textContent || td2.innerText;
                if ((txtValue1.toUpperCase().indexOf(filter2) > -1) && (parseInt(txtValue2) <= filter4)) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }

    else if ((filter1.length != 0) && (filter2.length != 0) && (filter3.length != 0) && (filter4.length == 0)) {

        for (i = 0; i < tr.length; i++) {

            td1 = tr[i].getElementsByTagName("td")[0];
            td2 = tr[i].getElementsByTagName("td")[1];
            var td3 = tr[i].getElementsByTagName("td")[2];


            if (td1 && td2 && td3) {
                txtValue1 = td1.textContent || td1.innerText;
                txtValue2 = td2.textContent || td2.innerText;
                var txtValue3 = td3.textContent || td3.innerText;

                if ((txtValue1.toUpperCase().indexOf(filter1) > -1) && (txtValue2.toUpperCase().indexOf(filter2) > -1) && (parseInt(txtValue3) >= filter3)) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }
    else if ((filter1.length != 0) && (filter2.length != 0) && (filter3.length == 0) && (filter4.length != 0)) {

        for (i = 0; i < tr.length; i++) {

            td1 = tr[i].getElementsByTagName("td")[0];
            td2 = tr[i].getElementsByTagName("td")[1];
            var td3 = tr[i].getElementsByTagName("td")[2];


            if (td1 && td2) {
                txtValue1 = td1.textContent || td1.innerText;
                txtValue2 = td2.textContent || td2.innerText;
                var txtValue3 = td3.textContent || td3.innerText;

                if ((txtValue1.toUpperCase().indexOf(filter1) > -1) && (txtValue2.toUpperCase().indexOf(filter2) > -1) && (parseInt(txtValue3) <= filter4)) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }
    else if ((filter1.length != 0) && (filter2.length != 0) && (filter3.length != 0) && (filter4.length != 0)) {
        for (i = 0; i < tr.length; i++) {

            td1 = tr[i].getElementsByTagName("td")[0];
            td2 = tr[i].getElementsByTagName("td")[1];
            var td3 = tr[i].getElementsByTagName("td")[2];


            if (td1 && td2) {
                txtValue1 = td1.textContent || td1.innerText;
                txtValue2 = td2.textContent || td2.innerText;
                var txtValue3 = td3.textContent || td3.innerText;

                if ((txtValue1.toUpperCase().indexOf(filter1) > -1) && (txtValue2.toUpperCase().indexOf(filter2) > -1) && (parseInt(txtValue3) >= filter3) && (parseInt(txtValue3) <= filter4)) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    }
}

function sortTable(n) {
    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById("filterTabela");
    switching = true;

    dir = "asc";

    while (switching) {

        switching = false;
        rows = table.rows;

        for (i = 1; i < (rows.length - 1); i++) {

            shouldSwitch = false;

            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];

            if (dir == "asc") {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {

                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc") {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {

                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            switchcount++;
        } else {
            if (switchcount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }
}
