import React, { Component } from 'react';
import { Button, Modal, Input, Dropdown } from 'semantic-ui-react';
import axios from '../../axios';

import './AssignExerciseModal.scss';

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
const sectionOptions = [
    { key: 1, text: 'Choice 1', value: 1 },
    { key: 2, text: 'Choice 2', value: 2 },
    { key: 3, text: 'Choice 3', value: 3 },
];
const exerciseOptions = [
    { key: 1, text: 'Choice 1', value: 1 },
    { key: 2, text: 'Choice 2', value: 2 },
    { key: 3, text: 'Choice 3', value: 3 },
];
const variantOptions = [
    { key: 1, text: 'Choice 1', value: 1 },
    { key: 2, text: 'Choice 2', value: 2 },
    { key: 3, text: 'Choice 3', value: 3 },
];

class AssignExerciseModal extends Component {
    state = {
        title: ''
    }

    addHandle = () => {
        console.log("Zapisz");
        //const nameData = this.state.name;
        //const surnameData = this.state.surname;
        //const emailData = this.state.email;

        // axios.post('', {
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
            <Modal trigger={<Button>Przypisz zadanie</Button>} centered={false}>
                <Modal.Header>Przypisz zadanie</Modal.Header>
                <Modal.Content >
                    <Dropdown className='studentInput' placeholder='Przedmiot' clearable options={subjectOptions} selection />
                    <Dropdown className='studentInput' placeholder='Grupa' clearable options={groupOptions} selection />
                    <Dropdown className='studentInput' placeholder='Sekcja' clearable options={sectionOptions} selection />
                    <Dropdown className='studentInput' placeholder='Zadanie' clearable options={exerciseOptions} selection />
                    <Dropdown className='studentInput' placeholder='Wariant' clearable options={variantOptions} selection />
                    <br />
                    <Input className='sectionInput' label='Data' placeholder='DD/MM/RRR' onChange={this.sectionHandle} />
                </Modal.Content>
                <Modal.Actions>
                    <Button primary onClick={this.addHandle}>Zapisz</Button>
                </Modal.Actions>
            </Modal>
        )
    }

}

export default AssignExerciseModal
