using System;
using System.Windows;
using System.Windows.Controls;
using client.data;

namespace client
{
    public class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MessageTemplate { get; set; }
        public DataTemplate MessageAttachmentTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            // Null value can be passed by IDE designer
            if (!(item is MessageModel message)) return null;
            return message.HasAttachment ? MessageAttachmentTemplate : MessageTemplate;
        }
    }
}