mergeInto(LibraryManager.library, {
    GetBrowserCanvasWidth: function () {
        var canvas = document.getElementById('unity-canvas');
        return canvas ? canvas.clientWidth : window.innerWidth;
    },
    GetBrowserCanvasHeight: function () {
        var canvas = document.getElementById('unity-canvas');
        return canvas ? canvas.clientHeight : window.innerHeight;
    }
});
