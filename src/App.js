import { Suspense } from 'react';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Layout from "./shared/Layout";
import AdminLayout from "./admin/shared/AdminLayout";
import UserLayout from './user/shared/UserLayout';

function App() {
  return (
    <Routes>

        <Route path='/*' element={<Layout />} />
        
        <Route path="admin/*" element={
          <Suspense fallback = {<>Loading...</>}> < AdminLayout /> </Suspense> }>
        </Route>

        <Route path="user/*" element={
          <Suspense fallback = {<>Loading...</>}> < UserLayout /> </Suspense> }>
        </Route>

    </Routes>
  );
}

export default App;
