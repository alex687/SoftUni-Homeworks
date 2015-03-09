use chatroom

db.createCollation('messages')


 db.messages.insert([{text: 'Test', date: new Date(), isRead: true, user:{usern
ame: 'pro', fullName: 'Chisto Pro', website: "http://test.com"}}])

> db.messages.insert({
...          text: "Tralalalal",
         date:  new Date(),
         isRead: false,
         user: {
             username: "gopa",
             fullName: "Gosho",
             website: "http://www.gosho.com/"
         }
     })

// Dump DB
 cd c: \data
 mongodump --dmob chatroom