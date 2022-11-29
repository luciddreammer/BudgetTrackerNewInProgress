import QuickActions from "./QuickActions"
import QuickData from "./QuickData";
import "./Header.css"
import React from "react";



export default function Header()
{
    return(
        <div className="header-split">
            <QuickActions/>
            <QuickData/>
        </div>
    );
}