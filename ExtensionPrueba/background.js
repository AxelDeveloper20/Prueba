chrome.tabs.onUpdated.addListener((tabId, changeInfo, tab) => {
    if (changeInfo.status === 'complete' && /^http/.test(tab.url)) {
        chrome.scripting.executeScript({
            target: { tabId: tabId },
            files: ["./buscaGoogle.js"]
        })
            .then(() => {
                console.log("La insercion esta completa.");
            })
            .catch(err => console.log(err));
    }
});