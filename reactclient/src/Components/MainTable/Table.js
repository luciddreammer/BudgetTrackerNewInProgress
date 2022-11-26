import "./Table.css"

export default function Table()
{
    return(
        <div>
            <table>
                <tr className="tr-border">
                    <th className="th-border">
                        Number
                    </th>
                    <th className="th-border">
                        Category
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
            </table>
        </div>
    )
}