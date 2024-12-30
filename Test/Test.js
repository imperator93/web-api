const mercedes = {
    name: "Mercedes S 1000",
    price: 29999.99,
    descriptions: ["very good", "super"],
}

const mazda = {
    name: "Mazda 3",
    price: 1999.99,
    descriptions: ["shit"],
}

// GET
// fetch("http://localhost:5233/products/5024").then(res => res.json()).then(data => console.log(data));

// POST

// fetch("http://localhost:5233/products", {
//     method: "POST",
//     headers: {
//         "content-type": "application/json"
//     },
//     body: JSON.stringify(mercedes)
// }).then(response => response.json()).then(data => console.log(data))

//UPDATE
// fetch("http://localhost:5233/products/5024", {
//     method: "PUT",
//     headers: {
//         "content-type": "application/json"
//     },
//     body: JSON.stringify(mazda),
// }).then(response => response.json()).then(data => console.log(data))

//DELETE
// fetch("http://localhost:5233/products/5024", {
//     method: "DELETE",
// }).then(response => response.json()).then(data => console.log(data))