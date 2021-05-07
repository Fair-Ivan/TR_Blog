var dig = {
    reload: function () {
        location.reload();
    },
    addPage: function (t, u, w, h, f) {
        top.dialog({
            title: t,
            url: u,
            width: w,
            height: h,
            onremove: function () { },
            onclose: f
        }).showModal();
    },
    remove: function () {
        var n = top.dialog.get(window);
        n.close().remove();
    },
    close: function () {
        var n = top.dialog.get(window);
        n.close();
    }

};

var diaMsg = {
    reload: function () {
        location.reload();
    },
    alert: function (title, content, width, height, successvalue, successFunc, errorvalue, errorFunc) {
        top.dialog({
            title: title,
            content: content,
            width: width,
            height: height,
            okValue: successvalue,
            ok: successFunc,
            cancelValue: errorvalue,
            cancel: errorFunc
        }).showModal();
    },
    remove: function () {
        var n = top.dialog.get(window);
        n.close().remove();
    },
    close: function () {
        var n = top.dialog.get(window);
        n.close();
    }

};