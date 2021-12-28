(function () {
    window.JobInterop = {
        refreshJobsData: () => {
            setInterval(() => { 
                document.getElementById("btnGetJobsData").click();
            }, 3000);
        }
    };
})();