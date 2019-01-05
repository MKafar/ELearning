import React, { Component } from 'react';
import { Button, Modal, Input, Dropdown } from 'semantic-ui-react';

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
    
    }

    render() {

        return (
            <Modal trigger={<Button primary>Przypisz zadanie</Button>} centered={false}>
                <Modal.Header>Przypisz zadanie</Modal.Header>
                <Modal.Content >
                    <Dropdown className='studentInput' placeholder='Przedmiot' clearable options={subjectOptions} selection />
                    <Dropdown className='studentInput' placeholder='Grupa' clearable options={groupOptions} selection />
                    <Dropdown className='studentInput' placeholder='Sekcja' clearable options={sectionOptions} selection />
                    <Dropdown className='studentInput' placeholder='Zadanie' clearable options={exerciseOptions} selection />
                    <Dropdown className='variantInput' placeholder='Wariant' clearable options={variantOptions} selection />
                    <Input className='dateInput' label='Data' placeholder='DD-MM-RRRR' onChange={this.sectionHandle} />
                </Modal.Content>
                <Modal.Actions>
                    <Button primary onClick={this.addHandle}>Zapisz</Button>
                </Modal.Actions>
            </Modal>
        )
    }

}

export default AssignExerciseModal
