import Header from "./HeaderComponents/Header";
import Table from "./MainTable/Table";
import FillTable from "./MainTable/FillTable";
import SearchForm from "./SearchForm/SearchForm";
import CategoryForm from "./AddCategoryForm/CategoryForm";
import React from "react";
import CategoryDropDown from "./CategoryDropDown";
import "./App.css"
import FillDropdown from "./FillDropdown";

export default function App()
{
    return(
        <div>
            <Header/>
            <div className="flex-it">
                <SearchForm/>
                <CategoryDropDown/>
            </div>
            <FillDropdown/>
            <CategoryForm />
            <Table/>
            <FillTable/>
            
        </div>
    );
}