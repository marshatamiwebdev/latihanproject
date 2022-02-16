function TSButton() {
    let name = "Fred";
    document.getElementById("ts-example").innerHTML = greeter(user);
}
class Student {
    constructor(firstName, middleInitial, lastName) {
        this.firstName = firstName;
        this.middleInitial = middleInitial;
        this.lastName = lastName;
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
}
function greeter(person) {
    return "Hello, " + person.firstName + " " + person.lastName;
}
function sayHello() {
    const compiler = document.getElementById("compiler")
        .value;
    const framework = document.getElementById("framework")
        .value;
    return `Hello from ${compiler} and ${framework}!`;
}
let user = new Student("Fred", "M.", "Smith");
//# sourceMappingURL=app.js.map