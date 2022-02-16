var jqtest = {
    showMsg: function () {
        let v = jQuery.fn.jquery.toString();
        let content = $("#ts-example-2")[0].innerHTML;
        alert(content.toString() + " " + v + "!!");
        $("#ts-example-2")[0].innerHTML = content + " " + v + "!!";
    }
};
jqtest.showMsg();
//# sourceMappingURL=library.js.map