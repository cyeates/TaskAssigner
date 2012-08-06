

var Ticket = function (description, tags) {
    this.description = description;
    this.tags = ko.observableArray(tags);
    this.tagsString = tags.join(", ");

};

var TicketsViewModel = function (tickets) {
    this.tickets = ko.observableArray(tickets);
    this.ticketToAdd = ko.observable("");

    var split = function (val) {
        return val.split(/,\s*/);
    }

    this.addTicket = function () {
        if (this.ticketToAdd() != "") {
            var tags;
            var $tags = $("#tags");
            if ($tags.val() != "") {
                tags = $tags.val().split(", ");
                $tags.val("");
            }

            this.tickets.push(new Ticket(this.ticketToAdd(), tags));
            this.ticketToAdd("");
        }


    };
};