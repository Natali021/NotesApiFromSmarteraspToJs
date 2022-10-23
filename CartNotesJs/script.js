document.addEventListener('DOMContentLoaded',()=>{
    //let urlApi = "https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5"
    let urlApi = "http://tasha021-001-site1.atempurl.com/Note";
    fetch(urlApi)
    .then((res)=>{
        return res.json();
        //console.log(res);
    })
    .then( function (data) {
        let container = document.getElementById('container');
        for (const iterator of data) {
            let cart = document.createElement('div');
            let id = iterator['id'];
            let header = iterator['header'];
            let text = iterator['text'];
            let dateOfCreation = iterator['dateOfCreation'];
            cart.setAttribute('class', 'cart');
            cart.setAttribute('id', id);
            //cart.innerText = '${header} {text} {dateOfCreation}';
            cart.innerText = header+"   "+text+"   "+dateOfCreation;
            container.append(cart);
        }
        console.log(data);
    })
    .catch((err)=>{
        console.error("BAD API");
    });
})
//idid	1
//header	"Lorem"
//text	"Lorem string"
//dateOfCreation	"2022-10-23T16:07:54.53"
//usersId	1 