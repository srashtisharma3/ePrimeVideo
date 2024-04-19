import React, { useState, useEffect } from 'react';
import { NavLink, useNavigate } from 'react-router-dom';
import authUser from '../helpers/authUser';
import { TAX } from '../helpers/constant';
import PlanService from '../services/PlanService';
import UtilService from '../services/UtilService';

export default function Pricing() {
    let navigate = useNavigate();
    const [planData, setPlanData] = useState([]);
    const user = authUser.Get();
    const handleSubscribe = function (id, name, price, currency) {
        let tax = Math.round(price * TAX.GST / 100);
        const plan = {
            id: id,
            name: name,
            price: price,
            tax: tax,
            total: price + tax,
            currency: currency,
            userId: user.id
        };
       // console.log(plan);
        const data = UtilService.Encrypt(plan);
        localStorage.setItem('p', data);
        navigate('/order');
    }
    useEffect(() => {
        PlanService.GetAll().then(res => {
            setPlanData(res.data);
        });
    }, []);

    return (
        <div>
            <div className="pricing-header p-3 pb-md-4 mx-auto text-center">
                <h1>Subscription Pricing</h1>
                <p className="fs-5 text-muted">Join eVideoPrime to watch the latest movies and TV shows. Enjoy secure, ad-free entertainment at a lower cost.</p>
            </div>
            <main>
                <div className="row text-center">
                    {planData.map((plan, index) => (
                        <div key={index} className="col">
                            <div className="card mb-4 rounded-3 shadow-sm border-default" >
                                <div className="card-header py-3  bg-default border-default" >
                                    <h4 className="my-0 fw-normal">{plan.name}</h4>
                                </div>
                                <div className="card-body">
                                    <h1 className="card-title pricing-card-title">{plan.currency} {plan.price}<small className="text-muted fw-light">/yr</small></h1>
                                    <ul className="list-unstyled mt-3 mb-4">
                                        <li>All Content</li>
                                        <li>Watch on TV or Laptop</li>
                                        <li>Ads Free Movies</li>
                                        <li>Video Quality ({plan.quality})</li>
                                    </ul>
                                    {user != null ? (
                                        <button
                                            type="button" className="w-100 text-white btn btn-lg btn-info" 
                                            onClick={(e) => handleSubscribe(plan.id, plan.name, plan.price, plan.currency)}
                                        >
                                            Subscribe Now
                                        </button>
                                    ) : (
                                        <NavLink
                                            to="/login?return=pricing" className="w-100 text-white btn btn-lg btn-info"
                                        >
                                            Subscribe Now
                                        </NavLink>
                                    )}
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
            </main>
        </div>
    );
}
