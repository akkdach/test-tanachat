import { useContext, useEffect,useState,createContext } from 'react';
import ReactDOM from "react-dom";
import './productCard.css';
import { ProductListContext } from '../Contexts/ProductListContext';
const ProductCard = ({ productData }) => {

  return (
    <div className='product-card'>
        <div className='product-card-body'>
            <p>ชื่อสินค้า {productData?? ""}</p>
            <p>ราคาสินค้า {productData ?? 0} / {productData ?? ""}</p>
            <p>สินค้าคงเหลือ {productData ?? 0}</p>
        </div>
        <div className='product-card-footer'>
            <button type="button" className='btn btn-primary'>เพิ่มไปยังตระกร้า</button>
        </div>
    </div>
  );
};


export default ProductCard;