import "./Table.css"
import React from "react"
import TableNames from "./TableNames"

export default function Table()
{
    return(
        <div >
            <table>
                <tbody >
                    <TableNames/>
                </tbody>
                <tbody id="single-div">
                </tbody>
            </table>
        </div>
    )
}