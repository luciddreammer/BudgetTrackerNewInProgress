import React from "react"
import "./SearchForm.css"
import { Fill } from "../MainTable/FillTable";

export default function SearchForm()
{
    
    const [formData, setFormData] = React.useState(
        {
            dateFrom: `${new Date().getFullYear()}-01-01`,
            dateTo: new Date().toJSON().slice(0,10),
            ammountFrom: 0,
            ammountTo: 0,
            whoPaid: ""
        }
    )
    function SendFilters()
    {
        const singleDiv = document.getElementById("single-div");
        singleDiv.innerHTML=""
        fetch('https://localhost:7095/Transaction/GetTransaction/ByFilters?' + new URLSearchParams({
            whoPaid: formData.whoPaid,
            from: formData.dateFrom,
            to: formData.dateTo,
            ammountFrom: formData.ammountFrom,
            ammountTo: formData.ammountTo
        }), {
            method: 'GET'
        })
        .then((response) => response.json())
        .then(data => data.map(el => {
            return(
                singleDiv.innerHTML = singleDiv.innerHTML + Fill(el.id, el.subCategory, el.user, el.ammount, el.dateTimeTransaction, el.description, el.whoPaid)
            )
        }))
    }

    function ChangeFormData(event)
    {
        const{name, value} = event.target
        setFormData(prevFormData => {
            return{
                ...prevFormData,
                [name]: value
            }
        })
    }

    function HandleChange(event)
    {
        ChangeFormData(event)
    }

    function HandleSubmit(event)
    {
        SendFilters()
        event.preventDefault()
    }

    function ResetForm()
    {
        setFormData(() => {return({
            dateFrom: `${new Date().getFullYear()}-01-01`,
            dateTo: new Date().toJSON().slice(0,10),
            ammountFrom: 0,
            ammountTo: 0,
            whoPaid: ""
        })})
        HandleSubmit();
    }

    return(
        <div>
            <form id="form-id" onSubmit={HandleSubmit}>
                <div>
                    <label htmlFor="whoPaid">Who paid</label>
                    <br></br>
                    <input
                        type="text"
                        placeholder="Who Paid for it"
                        name="whoPaid"
                        onChange={HandleChange}
                        value={formData.whoPaid}
                    />
                </div>

                <div>
                    <label htmlFor="dateFrom">Date from</label>
                    <br></br>
                    <input
                        type="date"
                        name="dateFrom"
                        onChange={HandleChange}
                        value={formData.dateFrom}
                    />
                </div>

                <div>
                    <label htmlFor="dateTo">Date To</label>
                    <br></br>
                    <input
                        type="date"
                        name="dateTo"
                        onChange={HandleChange}
                        value={formData.dateTo}
                    />
                </div>

                <div>
                    <label htmlFor="ammountFrom">Ammount From</label>
                    <br></br>
                    <input
                        type="number"
                        name="ammountFrom"
                        onChange={HandleChange}
                        value={formData.ammountFrom}
                        step="0.01"
                    />
                </div> 

                <div>
                    <label htmlFor="ammountTo">Ammount To</label>
                    <br></br>
                    <input
                        type="number"
                        name="ammountTo"
                        onChange={HandleChange}
                        value={formData.ammountTo}
                        step="0.01"
                    />
                </div>
                <button type="submit">Submit</button>
            </form>
            <button onClick={ResetForm}>Reset</button>
        </div>
    )
}