import Header from "./HeaderComponents/Header";
import Table from "./MainTable/Table";
import FillTable from "./MainTable/FillTable";
import SearchForm from "./SearchForm/SearchForm";

export default function App()
{
    return(
        <div>
            <Header/>
            <SearchForm/>
            <Table/>
            <FillTable/>
        </div>
    );
}