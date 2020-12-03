namespace UnityEngine.UI
{
    [AddComponentMenu("Layout/Dynamic Layout Group", 150)]
    /// <summary>
    /// Layout class for arranging child elements side by side.
    /// </summary>
    public class DynamicLayoutGroup : HorizontalOrVerticalLayoutGroup
    {

        protected DynamicLayoutGroup()
        { }

        /// <summary>
        /// Called by the layout system. Also see ILayoutElement
        /// </summary>
        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();
            CalcAlongAxis(0, false);
        }

        /// <summary>
        /// Called by the layout system. Also see ILayoutElement
        /// </summary>
        public override void CalculateLayoutInputVertical()
        {
            //base.CalculateLayoutInputVertical();
            //CalcAlongAxis(1, false);
        }

        /// <summary>
        /// Called by the layout system. Also see ILayoutElement
        /// </summary>
        public override void SetLayoutHorizontal()
        {
            SetCellsAlongAxis(0);
            //SetChildrenAlongAxis(0, false);
        }

        /// <summary>
        /// Called by the layout system. Also see ILayoutElement
        /// </summary>
        public override void SetLayoutVertical()
        {
            //SetCellsAlongAxis(1);
            //SetChildrenAlongAxis(1, false);
        }

        float positionX;
        float positionY;
        Vector2 parentSize;
        float startParentSizeY;
        //int numberOfRows;
        //float totalLength;
        private void SetCellsAlongAxis(int axis)
        {
            
            if (rectChildren.Count == 0) return;

            positionX = 0;
            positionY = 0;
            parentSize = rectTransform.sizeDelta;
            startParentSizeY = rectChildren[0].sizeDelta.y;
            //totalLength = 0;
            //numberOfRows = 0;

            for (int i = 0; i < rectChildren.Count; i++)
            {
                
                SetChildAlongAxis(rectChildren[i], 0, positionX);
                SetChildAlongAxis(rectChildren[i], 1, positionY);
                positionX += rectChildren[i].sizeDelta.x + m_Spacing;
                //totalLength += rectChildren[i].sizeDelta.x + m_Spacing;
                //numberOfRows = (int)(totalLength / rectTransform.sizeDelta.x);

                parentSize.y = positionY + startParentSizeY;
                rectTransform.sizeDelta = parentSize;

                if (positionX >= rectTransform.sizeDelta.x - rectChildren[i].sizeDelta.x)
                {
                    positionX = 0;
                    positionY += rectChildren[i].sizeDelta.y + m_Spacing;
                }

                
            }
        }

    }
}
