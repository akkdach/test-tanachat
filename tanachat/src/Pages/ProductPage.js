import { useContext, useEffect,useState } from 'react';
import ReactDOM from "react-dom";

import ProductCard from '../Components/productCard';
import servicePath from '../Configs/servicePath';
const ProductPage = ()=>{
    const [ productLists, setProductList ] = useState();
    const [title,setTitle] = useState();
    const getApiData = async (result) => {
        const res = await fetch(
            servicePath.getProduct
        ).then((response) => response.json());
        result(res.dataResult);
    };

    useEffect(()=>{
        getApiData((result)=>{
            setProductList(result)
        })
        setTitle("hellow");
       
    },[])

    const drawProduct = ()=>{
        <>
            {productLists.map((item)=>{
                <ProductCard productData={item}></ProductCard>
            })}
            
        </>
    }



    return (
        <div key='product'>
            {drawProduct}
        </div>
    );
};

export default ProductPage;