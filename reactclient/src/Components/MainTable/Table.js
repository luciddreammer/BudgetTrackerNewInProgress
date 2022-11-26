import "./Table.css"
import React from "react"

export default function Table()
{
    return(
        <div >
            <table>
                <tbody id="single-div">
                    <tr className="tr-border">
                        <th className="th-border">
                            Number
                        </th>
                        <th className="th-border">
                            User
                        </th>
                        <th className="th-border">
                            Sub-Category
                        </th>
                        <th className="th-border">
                            Ammount
                        </th>
                        <th className="th-border">
                            Transaction Date
                        </th>
                        <th className="th-border">
                            Description
                        </th>
                        <th className="th-border">
                            Who Paid
                        </th>
                    </tr>
                </tbody>
            </table>
        </div>
    )
}