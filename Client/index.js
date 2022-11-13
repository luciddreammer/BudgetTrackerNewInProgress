const getAllBtn = document.getElementById("get-all-btn")
const getAllDiv = document.getElementById("get-all-div")
const getByOwnerBtn = document.getElementById("get-by-owner-btn")
const getByOwnerDiv = document.getElementById("get-by-owner-div")
const newTransactionSubmit = document.getElementById("newTransaction")


getAllBtn.addEventListener("click", () =>{
 fetchData("https://localhost:7095/Transaction/GetTransactions",getAllDiv,"allTransactions")
})

getByOwnerBtn.addEventListener("click", () => {
    let owner = document.getElementById("ownerInput").value
    fetchData(`https://localhost:7095/Transaction/GetTransactions/${owner}`,getByOwnerDiv,"byOwner")
})

newTransactionSubmit.addEventListener("submit", function(e){
    e.preventDefault()
    const fname = document.getElementById("name").value;
    const fammount = document.getElementById("ammount").value;
    const fdate = document.getElementById("date").value;
    const fdescription = document.getElementById("description").value;
    const fwhoPaid = document.getElementById("whoPaid").value;
    const transaction = {
        name: fname,
        ammount: fammount,
        dateTimeTransaction: fdate,
        description: fdescription,
        whoPaid: fwhoPaid
    }

    const options = {
        method: "POST",
        mode: 'cors',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            name: fname,
            ammount: fammount,
            dateTimeTransaction: fdate,
            description: fdescription,
            whoPaid: fwhoPaid
        })
    }

    // console.log(formData)

    fetch("https://localhost:7095/Transaction/AddTransaction", options)
    .then(res => res.json())
    // .then(post => console.log(post))
    newTransactionSubmit.reset()
    })



function fetchData(url,div,tbl)
{
    div.innerHTML = `
    <table id=${tbl}>
        <tr>
            <th>Number</th>
            <th>Name</th>
            <th>Ammount</th>
            <th>Date</th>
            <th>Description</th>
            <th>WhoPaid</th>
            <th>Category</th>
        </tr>
    </table>`
    fetch(url)
    .then(res => res.json())
    .then(data => getResults(data,tbl))
}


function getResults(data,tbl)
{
    let tNumber = 1
    data.forEach(element => 
    {
        document.getElementById(tbl).innerHTML += `
        <tr>
            <th>${tNumber}</th>
            <th>${element.name}</th>
            <th>${element.ammount}</th>
            <th>${element.dateTimeTransaction}</th>
            <th>${element.description}</th>
            <th>${element.whoPaid}</th>
            <th>${element.category}</th>
        </tr>
        `
        tNumber++
    })   
}