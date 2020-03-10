// Shorthand for $( document ).ready()
$(function () {

    function modalJs(id, options) {
        console.log("modalJs");
        console.log(id);
        console.log(options);
        var idto = '#' + id;
        $(idto).modal(options);
    }
    function onfocus(id) {
        var idto = '#' + id;
        $(idto).focus();
    }

    //用于C# IJSRuntime 调用
    window.exampleJsFunctions = {
        showPrompt: function (message) {
            return prompt(message, 'Type anything here');
        },
        modalJs: modalJs,
        onfocusJs: onfocus
    };

});