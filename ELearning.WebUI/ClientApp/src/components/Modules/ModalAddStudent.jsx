import React, { Component } from 'react';
import { Button, Modal, Input } from 'semantic-ui-react';
import axios from '../../axios';

import './ModalAddStudent.scss';

class ModalAddStudent extends Component {
    
    nameHandle = (e) => {
        this.setState({ name: e.target.value })
    }
    surnameHandle = (e) => {
        this.setState({ surname: e.target.value })
    }
    emailHandle = (e) => {
        this.setState({ email: e.target.value })
    }

    addHandle = () => {
        const nameData = this.state.name;
        const surnameData = this.state.surname;
        const emailData = this.state.email;

        axios.post('/api/Users/Create', {
            name: nameData,
            surname: surnameData,
            email: emailData
        })
            .then(response => {
                console.log(response);
                this.props.updateData();
            })
            .catch(error => {
                console.log(error.response);
                alert("Niepoprawne dane!");
            })
    }

    render() {

        return (
            <Modal trigger={<Button primary>Dodaj studenta</Button>} centered={false} closeIcon>
                <Modal.Header>Dodaj studenta</Modal.Header>
                <Modal.Content >
                    <Input className='studentInput' placeholder='Imię' onChange={this.nameHandle} />
                    <Input className='studentInput' placeholder='Nazwisko' onChange={this.surnameHandle} />
                    <Input className='studentInput' placeholder='mail@student.polsl.pl' onChange={this.emailHandle} />

                </Modal.Content>
                <Modal.Actions>
                <Button primary onClick={()=>{
                        this.addHandle();
                        this.props.updateData();}}> Zapisz</Button>
                </Modal.Actions>
            </Modal>
        )
    }

}

export default ModalAddStudent
