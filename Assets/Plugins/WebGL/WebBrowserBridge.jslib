mergeInto(LibraryManager.library, {
    GetBrowserCanvasWidth: function () {
        var canvas = document.getElementById('unity-canvas');
        return canvas ? canvas.clientWidth : window.innerWidth;
    },
    
    GetBrowserCanvasHeight: function () {
        var canvas = document.getElementById('unity-canvas');
        return canvas ? canvas.clientHeight : window.innerHeight;
    },

    RegisterFullscreenListener: function () {
        if (typeof window._fullscreenListenerRegistered !== 'undefined') return;
        window._fullscreenListenerRegistered = true;

        document.addEventListener('fullscreenchange', function () {
            if (!document.fullscreenElement) {
                try {
                    if (window.myUnityInstance) {
                        // Change 'ResolutionManager' to match your GameObject's name: 'Scene Manager'
                        window.myUnityInstance.SendMessage('Scene Manager', 'OnFullscreenExitExternal');
                    }
                } catch (e) {
                    console.log("Could not send fullscreen exit message to Unity: ", e);
                }
            }
        });

        window.addEventListener('resize', function () {
            try {
                if (window.myUnityInstance) {
                    window.myUnityInstance.SendMessage('Scene Manager', 'OnWindowResizedExternal');
                }
            } catch (e) {
                console.log("Could not send window resize message to Unity: ", e);
            }
        });
    }
});