var barraDeBusca = document.querySelector(".busca-container");

document.addEventListener("click", function(event) {
    if(event.target.closest("#busca")) {
        barraDeBusca.classList.add("buscando");
        return
    }
    barraDeBusca.classList.remove("buscando");
})

