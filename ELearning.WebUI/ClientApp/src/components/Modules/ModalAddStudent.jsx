import React, { Component } from 'react';
import { Button, Modal, Input, Dropdown } from 'semantic-ui-react';
import axios from '../../axios';

import './ModalAddStudent.scss';

const subjectOptions = [
    { key: 1, text: 'Choice 1', value: 1 },
    { key: 2, text: 'Choice 2', value: 2 },
    { key: 3, text: 'Choice 3', value: 3 },
];
const groupOptions = [
    { key: 1, text: 'Choice 1', value: 1 },
    { key: 2, text: 'Choice 2', value: 2 },
    { key: 3, text: 'Choice 3', value: 3 },
];

class ModalAddStudent extends Component {
    state = {
        title: ''
    }

    nameHandle = (e) => {
        this.setState({ name: e.target.value })
    }
    surnameHandle = (e) => {
        this.setState({ surname: e.target.value })
    }
    emailHandle = (e) => {
        this.setState({ email: e.target.value })
    }
    sectionHandle = (e) => {
        this.setState({ number: e.target.value })
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
            })
            .catch(error => {
                console.log(error.response);
            })

        // axios.post('/api/Users/Create', {
        //     name: nameData,
        //     surname: surnameData,
        //     email: emailData
        // })
        //     .then(response => {
        //         console.log(response);
        //     })
        //     .catch(error => {
        //         console.log(error.response);
        //     })
    }

    addtolistHandle = () => {
        console.log("Dodano do listy");
    }

    render() {



        return (
            <Modal trigger={<Button>Dodaj studenta</Button>} centered={false}>
                <Modal.Header>Dodaj studenta</Modal.Header>
                <Modal.Content >
                        <Input className='studentInput' placeholder='Imię' onChange={this.nameHandle} />
                        <Input className='studentInput' placeholder='Nazwisko' onChange={this.surnameHandle} />
                        <Input className='studentInput' placeholder='mail@student.polsl.pl' onChange={this.emailHandle} />
                        <Dropdown className='studentInput' placeholder='Laboratorium' clearable options={subjectOptions} selection />
                        <Dropdown className='studentInput' placeholder='Grupa' clearable options={groupOptions} selection />
                        <Input className='sectionInput' placeholder='Sekcja' onChange={this.sectionHandle} />
                        <Button className='addtolistbutton' primary onClick={this.addtolistHandle}>Dodaj</Button>

                </Modal.Content>
                <Modal.Actions>
                    <Button primary onClick={this.addHandle}>Zapisz</Button>
                </Modal.Actions>
            </Modal>
        )
    }

}

export default ModalAddStudent
