import React from 'react'
import { Container, List, Button } from 'semantic-ui-react'

import './DetailList.scss'

const DetailList  = (props) => {

    return (
        <div className='detailList'>
            <Container>
                <List divided relaxed>
                    <List.Item>
                        <List.Content floated='right'>
                            { props.visibledetail ? <Button onClick={props.detailsClicked}> Szczegóły </Button> : null }
                            { props.visibledelete ? <Button onClick={props.removeClicked}> Usuń </Button> : null }
                            { props.studentgrade }
                        </List.Content>
                        {/* <List.Content floated='left'>
                            { props.id }
                        </List.Content> */}
                        <List.Content  floated='left'>
                            { props.date }
                        </List.Content>
                        <List.Content >
                            { props.text }
                            { props.title }
                            { props.number}
                            { props.name }
                        </List.Content>
                        <List.Content floated='left' >
                            { props.variant }
                            { props.subject }
                            
                        </List.Content>
                        <List.Content floated='left'>
                            { props.group }
                            { props.grade}
                        </List.Content>
                    </List.Item>
                </List>
            </Container>

        </div>

    );
}

export default DetailList;