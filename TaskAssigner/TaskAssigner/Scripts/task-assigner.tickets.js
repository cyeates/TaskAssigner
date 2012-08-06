

var Ticket = function (description, tags) {
    this.description = description;
    this.tags = tags;
    this.tagsString = tags.join(", ");

};

var TicketsViewModel = function (tickets) {
    this.tickets = ko.observableArray(tickets);
    this.ticketToAdd = ko.observable("");


    var saveTicket = function (ticket) {

        var dto = {};
        dto.Description = ticket.description;
        dto.Tags = ticket.tags;
        $.ajax({
            type: "POST",
            url: "Tickets/Create",
            data: JSON.stringify(dto),
            dataType: "json", 
            contentType: "application/json; charset=utf-8",
            success: function (result) {

            }
        });
    };

    this.addTicket = function () {
        if (this.ticketToAdd() != "") {
            var tags;
            var $tags = $("#tags");
            if ($tags.val() != "") {
                tags = $tags.val().split(", ");
                $tags.val("");
            }

            var ticket = new Ticket(this.ticketToAdd(), tags);
            saveTicket(ticket);
            this.tickets.push(ticket);
            this.ticketToAdd("");
        }



    };
};