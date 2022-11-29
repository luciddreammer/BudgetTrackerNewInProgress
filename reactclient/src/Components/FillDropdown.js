import { useEffect } from "react";

function getObjects()
    {
        const listEl = document.getElementById("list")
        fetch("https://localhost:7095/Category/GetAllCategories")
        .then(response => response.json())
        .then(categories => categories.map(category =>
            {
                return(
                    listEl.innerHTML = listEl.innerHTML + `<option>${category.name}</option>`
                )
            }
        ))
        // const dataS = ['some', 'data', 'for', 'example']
        // dataS.map(data => {
        //     return(
        //         listEl.innerHTML = listEl.innerHTML + `<option>${data}</option>`
        //     )
        // })
    }

export default function FillDropdown()
{
    
    useEffect(() => getObjects(),[])
    
}