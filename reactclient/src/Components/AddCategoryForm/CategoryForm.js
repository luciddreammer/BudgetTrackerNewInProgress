import React from "react"


export default function CategoryForm()
{
    const [category, setCategory] = React.useState(
        {
            name: "",
            // userId: 666
        }
    )

    function AddCategory(event)
    {
        // event.preventDefault()
        const options = {
            method: "POST",
            mode: 'cors',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                name: category.name,
                // userId: category.userId
            })
        }
        fetch("https://localhost:7095/Category/AddCategory", options)
        .then(res => res.json())
    }

    function ChangeValue(event)
    {
        const{name, value} = event.target
        setCategory(prevFormData => {
            return{
                ...prevFormData,
                [name]: value
            }
        })
    }

    return(
        <div>
            <h1>Category Form</h1>
            <form onSubmit={AddCategory}>
                <input 
                    name="name"
                    type="text"
                    onChange={ChangeValue}
                    value={category.name}
                />
                <button type="submit">Add Category</button>
            </form>
        </div>
        
    )
}