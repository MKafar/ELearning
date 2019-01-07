import React from 'react';
import AssignExerciseModal from '../../components/Modules/AssignExerciseModal';
import { Header } from 'semantic-ui-react';

import './AdminHome.scss';

const AdminHome = () => (
    <div className='adminhome'>
        <Header size="large">Witaj Admina Inez!</Header>
        <AssignExerciseModal />
    </div>
)

export default AdminHome;
