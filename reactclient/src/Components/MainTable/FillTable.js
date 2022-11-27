import { useEffect } from "react"

export function Fill(id, user, subCategory, ammount, transactionDate, description, whoPaid)
{
    console.log("Filled")
   return( 
    `<tr className="tr-border">
        <th className="th-border">
            ${id}
        </th>
        <th className="th-border">
            ${subCategory}
        </th>
        <th className="th-border">
            ${user}
         </th>
        <th className="th-border">
            ${ammount}
        </th>
        <th className="th-border">
            ${SliceDateTime(transactionDate)}
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
    if(dateTime.length > 19)
    {
        dateTime = dateTime.slice(0,19)
    }
    dateTime = dateTime.replace("T", " ")
    return dateTime;
}

function GetData()
{
    const singleDiv = document.getElementById("single-div");
    fetch('https://localhost:7095/Transaction/GetTransactions')
    .then((response) => response.json())
    .then(data => data.map(el => {
        return(
            singleDiv.innerHTML = singleDiv.innerHTML + Fill(el.id, el.subCategory, el.user, el.ammount, el.dateTimeTransaction, el.description, el.whoPaid)
        )
    }))
}   

export default function FillTable()
{
   useEffect(() => GetData(), []);
}
