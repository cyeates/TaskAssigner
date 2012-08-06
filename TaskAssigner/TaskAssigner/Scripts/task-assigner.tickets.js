

var Ticket = function (description, tags) {
    this.description = description;
    this.tags = ko.observableArray(tags);

    this.addTag = function (tagToAdd) {
        this.tags.push(tagToAdd);
    };

}

var TicketsViewModel = function (tickets) {
    this.tickets = ko.observableArray(tickets);
    this.ticketToAdd = ko.observable("");

    this.addTicket = function () {
        if (this.ticketToAdd() != "") {
            this.tickets.push(new Ticket(this.ticketToAdd()));
            this.ticketToAdd("");
        }
    };
 }