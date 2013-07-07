$(document).ready(function () {
    $("#Street").keyup(GetTableWithTickets);
    $("#Home").keyup(GetTableWithTickets);
    $("#Appartment").keyup(GetTableWithTickets);
});

function GetTableWithTickets(event) {
    $.ajax({
        url: "http://" + window.location.host + "/Ticket/ListOfTickets",
        data: { street: $("#Street").val(), home: $("#Home").val(), appartment: $("#Appartment").val() }
    })
      .done(function (table) {
          $('#listOfAvailibleTickets').empty();
          $('#listOfAvailibleTickets').append(table);

      })
      .fail(function (xhr, ajaxOptions, thrownError) {
          alert(xhr.status);
          alert(thrownError);

      });
}