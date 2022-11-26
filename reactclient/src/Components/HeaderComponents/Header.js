import QuickActions from "./QuickActions"
import QuickData from "./QuickData";
import "./Header.css"



export default function Header()
{
    return(
        <div className="header-split">
            <QuickActions/>
            <QuickData/>
        </div>
    );
}