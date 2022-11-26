import { useEffect } from "react"


function Fill(div, id, category, subCategory, ammount, transactionDate, description, whoPaid)
{
   return(div = div + 
    `<tr className="tr-border">
        <th className="th-border">
            ${id}
        </th>
        <th className="th-border">
            ${category}
        </th>
        <th className="th-border">
            ${subCategory}
        </th>
        <th className="th-border">
            ${ammount}
        </th>
        <th className="th-border">
            ${transactionDate}
        </th>
        <th className="th-border">
            ${description}
        </th>
        <th className="th-border">
            ${whoPaid}
        </th>
    </tr>`)
}

function SliceDateTime(dateTime)
{
    let newDate;
    if(dateTime.length>19)
    {
        newDate = dateTime.slice(0,19)
    }
    if(dateTime.length<=19)
    {
        newDate = dateTime.slice(0,19)
    }
    const replaced = newDate.replace("T", " ")
    return replaced;
}


function GetData()
{
    const singleDiv = document.getElementById("single-div");
    fetch('https://localhost:7095/Transaction/GetTransactions')
    .then((response) => response.json())
    .then((data) => data.map(el => {
        // console.log(el.dateTimeTransaction.length)
        singleDiv.innerHTML = singleDiv.innerHTML + 
        `<tr className="tr-border">
            <th className="th-border">
                ${el.id}
            </th>
            <th className="th-border">
                ${el.subCategory}
            </th>
            <th className="th-border">
                ${el.user}
            </th>
            <th className="th-border">
                ${el.ammount} zł
            </th>
            <th className="th-border">
                ${SliceDateTime(el.dateTimeTransaction)}
            </th>
            <th className="th-border">
                ${el.description}
            </th>
            <th className="th-border">
                ${el.whoPaid}
            </th>
        </tr>`
        }
    ))
}   






export default function FillTable()
{
    


   useEffect(() => GetData(), []);
}