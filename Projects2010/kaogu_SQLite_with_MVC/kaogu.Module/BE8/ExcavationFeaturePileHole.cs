using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace kaogu.Module
{
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Id")]
    [Custom("Caption", "���Ӷ�״�ż��Ǽ�")]
    public class ExcavationFeaturePileHole : BaseObject
    {
        public ExcavationFeaturePileHole(Session session) : base(session) { }

        [Custom("Caption", "��¼��")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("Caption", "��¼����")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "������ַ")]
        public string BelongSite
        {
            get { return GetPropertyValue<string>("BelongSite"); }
            set { SetPropertyValue("BelongSite", value); }
        }

        [Custom("Caption", "���Ӷ�״�ż����")]
        public String Id
        {
            get { return GetPropertyValue<String>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "�Ƿ�����")]
        public IsMainOrPart MainOrPart
        {
            get { return GetPropertyValue<IsMainOrPart>("MainOrPart"); }
            set { SetPropertyValue("MainOrPart", value); }
        }


        [Association("ExcavationFeaturePileHole-Worker", typeof(Worker))]
        [Custom("Caption", "������Ա")]
        public XPCollection Worker
        {
            get { return GetCollection("Worker"); }
        }


        [Custom("Caption", "����������")]
        public DateTime StartOn
        {
            get { return GetPropertyValue<DateTime>("StartOn"); }
            set { SetPropertyValue("StartOn", value); }
        }

        [Custom("Caption", "����������")]
        public DateTime EndOn
        {
            get { return GetPropertyValue<DateTime>("EndOn"); }
            set { SetPropertyValue("EndOn", value); }
        }

        [Custom("Caption", "�ù�")]
        public string FWorker
        {
            get { return GetPropertyValue<string>("FWorker"); }
            set { SetPropertyValue("EndOn", value); }
        }


        //����λ��
        [Custom("Caption", "��������")]
        public string GPS
        {
            get { return GetPropertyValue<string>("GPS"); }
            set { SetPropertyValue("GPS", value); }
        }

        [Custom("Caption", "����λ������һ")]
        public string GPSDescription
        {
            get { return GetPropertyValue<string>("GPSDescription"); }
            set { SetPropertyValue("GPSDescription", value); }
        }

        [Custom("Caption", "��������")] //ȫվ��
        public string TotalStation
        {
            get { return GetPropertyValue<string>("TotalStation"); }
            set { SetPropertyValue("TotalStation", value); }
        }

        [Custom("Caption", "����λ��������")]
        public string TotalStationDescription
        {
            get { return GetPropertyValue<string>("TotalStationDescription"); }
            set { SetPropertyValue("TotalStationDescription", value); }
        }

        [Custom("Caption", "�����ż�")]
        public string BelongFeature
        {
            get { return GetPropertyValue<string>("BelongFeature"); }
            set { SetPropertyValue("BelongFeature", value); }
        }

        //������Ϣ
        //��Ȼ����
        [Custom("Caption", "����")]
        public string Terrain
        {
            get { return GetPropertyValue<string>("Terrain"); }
            set { SetPropertyValue("Terrain", value); }
        }

        [Custom("Caption", "��ò")]
        public string Landform
        {
            get { return GetPropertyValue<string>("Landform"); }
            set { SetPropertyValue("Landform", value); }
        }

        [Custom("Caption", "ˮ��")]
        public string Hydrology
        {
            get { return GetPropertyValue<string>("Hydrology"); }
            set { SetPropertyValue("Hydrology", value); }
        }

        [Custom("Caption", "ֲ��")]
        public string Vege
        {
            get { return GetPropertyValue<string>("Vege"); }
            set { SetPropertyValue("Vege", value); }
        }

        [Custom("Caption", "����״��")]
        public string KeepState
        {
            get { return GetPropertyValue<string>("KeepState"); }
            set { SetPropertyValue("KeepState", value); }
        }

        [Custom("Caption", "����ʽ")]
        public string CleanType
        {
            get { return GetPropertyValue<string>("CleanType"); }
            set { SetPropertyValue("CleanType", value); }
        }

        [Custom("Caption", "�ֲ�λ��")]
        public string SpreadLocation
        {
            get { return GetPropertyValue<string>("SpreadLocation"); }
            set { SetPropertyValue("SpreadLocation", value); }
        }

        //�������ż���λ��λ�ù�ϵ ��Զ�
        [Custom("Caption", "�������ż���λ��λ�ù�ϵ")]
        [Association("ExcavationFeaturePileHole-Layer", typeof(Layer))]
        public XPCollection Layer
        {
            get { return GetCollection("Layer"); }
        }

        [Custom("Caption", "��������")]
        public string LayerDescription
        {
            get { return GetPropertyValue<string>("LayerDescription"); }
            set { SetPropertyValue("LayerDescription", value); }
        }


        //����
        [Custom("Caption", "�����ż�")]
        public string AdditionFeature
        {
            get { return GetPropertyValue<string>("AdditionFeature"); }
            set { SetPropertyValue("AdditionFeature", value); }
        }

        //�ر���

        //����ǰ

        // �ر��¶�
        [Custom("Caption", "�ر��¶ȷ���")]
        public string LandSlopeLocation
        {
            get { return GetPropertyValue<string>("LandSlopeLocation"); }
            set { SetPropertyValue("LandSlopeLocation", value); }
        }
        [Custom("Caption", "�ر��¶ȽǶ�")]
        public int LandSlopeDegree
        {
            get { return GetPropertyValue<int>("LandSlopeDegree"); }
            set { SetPropertyValue("LandSlopeDegree", value); }
        }

        [Custom("Caption", "ƽ����״")]
        public string PlaneShape
        {
            get { return GetPropertyValue<string>("PlaneShape"); }
            set { SetPropertyValue("PlaneShape", value); }
        }

        [Custom("Caption", "������״")]
        public string SideShape
        {
            get { return GetPropertyValue<string>("SideShape"); }
            set { SetPropertyValue("SideShape", value); }
        }

        [Custom("Caption", "������״")]
        public string ProfileShape
        {
            get { return GetPropertyValue<string>("ProfileShape"); }
            set { SetPropertyValue("ProfileShape", value); }
        }

        //����
        //���� 
        [Custom("Caption", "�Ƿ񳤻�ֱ��")]
        public IsLengthOrDiameter SIzeEntireIsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("SIzeEntireIsLengthOrDiameter"); }
            set { SetPropertyValue("SIzeEntireIsLengthOrDiameter", value); }
        }


        [Custom("Caption", "��/ֱ��")]
        public float SizeEntireLength
        {
            get { return GetPropertyValue<float>("SizeEntireLength"); }
            set { SetPropertyValue("SizeEntireLength", value); }
        }

        [Custom("Caption", "��")]
        public float SizeEntireWidth
        {
            get { return GetPropertyValue<float>("SizeEntireWidth"); }
            set { SetPropertyValue("SizeEntireWidth", value); }
        }

        [Custom("Caption", "��")]
        public float SizeEntireHeight
        {
            get { return GetPropertyValue<float>("SizeEntireHeight"); }
            set { SetPropertyValue("SizeEntireHeight", value); }
        }

        //����

        [Custom("Caption", "�Ƿ񳤻�ֱ��")]
        public IsLengthOrDiameter SIzeSunkerIsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("SIzeSunkerIsLengthOrDiameter"); }
            set { SetPropertyValue("SIzeSunkerIsLengthOrDiameter", value); }
        }
        [Custom("Caption", "��/ֱ��")]
        public float SizeSunkerLength
        {
            get { return GetPropertyValue<float>("SizeSunkerLength"); }
            set { SetPropertyValue("SizeSunkerLength", value); }
        }

        [Custom("Caption", "��")]
        public float SizeSunkerWidth
        {
            get { return GetPropertyValue<float>("SizeSunkerWidth"); }
            set { SetPropertyValue("SizeSunkerWidth", value); }
        }

        [Custom("Caption", "��")]
        public float SizeSunkerDepth
        {
            get { return GetPropertyValue<float>("SizeSunkerDepth"); }
            set { SetPropertyValue("SizeSunkerDepth", value); }
        }

        //������
        //ʯ��
        [Custom("Caption", "��Χ")]
        public string StoneRange
        {
            get { return GetPropertyValue<string>("StoneRange"); }
            set { SetPropertyValue("StoneRange", value); }
        }

        [Custom("Caption", "�ʵ�")]
        public string StoneQuality
        {
            get { return GetPropertyValue<string>("StoneQuality"); }
            set { SetPropertyValue("StoneQuality", value); }
        }


        [Custom("Caption", "��ɫ")]
        public string StoneColor
        {
            get { return GetPropertyValue<string>("StoneColor"); }
            set { SetPropertyValue("StoneColor", value); }
        }

        [Custom("Caption", "����")]
        public string StoneProportion
        {
            get { return GetPropertyValue<string>("StoneProportion"); }
            set { SetPropertyValue("StoneProportion", value); }
        }

        [Custom("Caption", "��ѡ��")]
        public int StoneClassification
        {
            get { return GetPropertyValue<int>("StoneClassification"); }
            set { SetPropertyValue("StoneClassification", value); }
        }

        [Custom("Caption", "ĥԲ��")]
        public int StoneSmooth
        {
            get { return GetPropertyValue<int>("StoneSmooth"); }
            set { SetPropertyValue("StoneSmooth", value); }
        }

        [Custom("Caption", "��С�ߴ�")]
        public float StoneMinSize
        {
            get { return GetPropertyValue<float>("StoneMinSize"); }
            set { SetPropertyValue("StoneMinSize", value); }
        }

        [Custom("Caption", "���ߴ�")]
        public float StoneMaxSize
        {
            get { return GetPropertyValue<float>("StoneMaxSize"); }
            set { SetPropertyValue("StoneMaxSize", value); }
        }

        [Custom("Caption", "ƽ���ߴ�")]
        public float StoneAverageSize
        {
            get { return GetPropertyValue<float>("StoneAverageSize"); }
            set { SetPropertyValue("StoneAverageSize", value); }
        }

        //ֲ�� һ�Զ�
        [Custom("Caption", "ֲ��(��Χ-����-��ɫ-�߶�-����)")]
        [Association("ExcavationFeaturePileHole-Vegetation", typeof(Vegetation))]
        public XPCollection Vegetation
        {
            get { return GetCollection("Vegetation"); }
        }

        //�ѻ�
        [Custom("Caption", "�ر����ѻ�")]

        [Association("ExcavationFeaturePileHole-Accumulation1", typeof(Accumulation))]
        public XPCollection Accumulation1
        {
            get { return GetCollection("Accumulation1"); }
        }
        //������

        [Custom("Caption", "�ر���������")]

        [Association("ExcavationFeaturePileHole-RemainMark1", typeof(RemainMark))]
        public XPCollection RemainMark1
        {
            get { return GetCollection("RemainMark1"); }
        }

        //ע�⣺�����ر����������״������������ѻ�������о������ƶ�Ĺ��ر����Ľ�����ʽ���������ϡ��������̣���
        [Custom("Caption", "�ر�������")]
        public string SurfaceBuildingDescription
        {
            get { return GetPropertyValue<string>("SurfaceBuildingDescription"); }
            set { SetPropertyValue("SurfaceBuildingDescription", value); }
        }


        //���½���

        [Custom("Caption", "�ӿ��ڶ���λ��")]
        public string HoleUnderPilePosition
        {
            get { return GetPropertyValue<string>("HoleUnderPilePosition"); }
            set { SetPropertyValue("HoleUnderPilePosition", value); }
        }

        //���� ����

        [Custom("Caption", "����һ")]
        public string Direction1
        {
            get { return GetPropertyValue<string>("Direction1"); }
            set { SetPropertyValue("Direction1", value); }
        }

        [Custom("Caption", "�Ƿ񳤻�ֱ��")]
        public IsLengthOrDiameter TotalIsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("TotalIsLengthOrDiameter"); }
            set { SetPropertyValue("TotalIsLengthOrDiameter", value); }
        }

        [Custom("Caption", "��/ֱ����m��")]
        public float DirectionLength
        {
            get { return GetPropertyValue<float>("DirectionLength"); }
            set { SetPropertyValue("DirectionLength", value); }
        }

        [Custom("Caption", "�����")]
        public string Direction2
        {
            get { return GetPropertyValue<string>("Direction2"); }
            set { SetPropertyValue("Direction2", value); }
        }

        [Custom("Caption", "��m��")]
        public float DirectionWidth
        {
            get { return GetPropertyValue<float>("DirectionWidth"); }
            set { SetPropertyValue("DirectionWidth", value); }
        }

        //���
        [Custom("Caption", "����")]
        public float Deepest
        {
            get { return GetPropertyValue<float>("Deepest"); }
            set { SetPropertyValue("Deepest", value); }
        }

        [Custom("Caption", "λ��")]
        public string DeepestPosition
        {
            get { return GetPropertyValue<string>("DeepestPosition"); }
            set { SetPropertyValue("DeepestPosition", value); }
        }


        [Custom("Caption", "��ǳ")]
        public float Shallowest
        {
            get { return GetPropertyValue<float>("Shallowest"); }
            set { SetPropertyValue("Shallowest", value); }
        }

        [Custom("Caption", "λ��")]
        public string ShallowestPosition
        {
            get { return GetPropertyValue<string>("ShallowestPosition"); }
            set { SetPropertyValue("ShallowestPosition", value); }
        }

        //��Ե
        [Custom("Caption", "��״")]
        public string EdgeShape
        {
            get { return GetPropertyValue<string>("EdgeShape"); }
            set { SetPropertyValue("EdgeShape", value); }
        }

        [Custom("Caption", "���������")]
        public string EdgeMaterial
        {
            get { return GetPropertyValue<string>("EdgeMaterial"); }
            set { SetPropertyValue("EdgeMaterial", value); }
        }

        [Custom("Caption", "��ɫ")]
        public string EdgeColor
        {
            get { return GetPropertyValue<string>("EdgeColor"); }
            set { SetPropertyValue("EdgeColor", value); }
        }

        //��Ե����Size

        [Custom("Caption", "����һ")]
        public string EdgeSizeDirection1
        {
            get { return GetPropertyValue<string>("EdgeSizeDirection1"); }
            set { SetPropertyValue("EdgeSizeDirection1", value); }
        }

        [Custom("Caption", "�Ƿ񳤻�ֱ��")]
        public IsLengthOrDiameter EdgeSizeIsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("EdgeSizeIsLengthOrDiameter"); }
            set { SetPropertyValue("EdgeSizeIsLengthOrDiameter", value); }
        }

        [Custom("Caption", "��/ֱ����m��")]
        public float EdgeSizeDirectionLength
        {
            get { return GetPropertyValue<float>("EdgeSizeDirectionLength"); }
            set { SetPropertyValue("EdgeSizeDirectionLength", value); }
        }

        [Custom("Caption", "�����")]
        public string EdgeSizeDirection2
        {
            get { return GetPropertyValue<string>("EdgeSizeDirection2"); }
            set { SetPropertyValue("EdgeSizeDirection2", value); }
        }

        [Custom("Caption", "��m��")]
        public float EdgeSizeDirectionWidth
        {
            get { return GetPropertyValue<float>("EdgeSizeDirectionWidth"); }
            set { SetPropertyValue("EdgeSizeDirectionWidth", value); }
        }

        [Custom("Caption", "�ߣ�m��")]
        public float EdgeSizeDirectionHeight
        {
            get { return GetPropertyValue<float>("EdgeSizeDirectionHeight"); }
            set { SetPropertyValue("EdgeSizeDirectionHeight", value); }
        }

        [Custom("Caption", "�m��")]
        public float EdgeSizeDirectionDepth
        {
            get { return GetPropertyValue<float>("EdgeSizeDirectionDepth"); }
            set { SetPropertyValue("EdgeSizeDirectionDepth", value); }
        }


        //���������� BulitSize
        [Custom("Caption", "��״")]
        public string EdgeBulitSizeShape
        {
            get { return GetPropertyValue<string>("EdgeBulitSizeShape"); }
            set { SetPropertyValue("EdgeBulitSizeShape", value); }
        }

        [Custom("Caption", "�Ƿ񳤻�ֱ��")]
        public IsLengthOrDiameter EdgeBulitSizeIsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("EdgeBulitSizeIsLengthOrDiameter"); }
            set { SetPropertyValue("EdgeBulitSizeIsLengthOrDiameter", value); }
        }

        [Custom("Caption", "��/ֱ����m��")]
        public float EdgeBulitSizeLength
        {
            get { return GetPropertyValue<float>("EdgeBulitSizeLength"); }
            set { SetPropertyValue("EdgeBulitSizeLength", value); }
        }


        [Custom("Caption", "��m��")]
        public float EdgeBulitSizeWidth
        {
            get { return GetPropertyValue<float>("EdgeBulitSizeWidth"); }
            set { SetPropertyValue("EdgeBulitSizeWidth", value); }
        }

        [Custom("Caption", "�ߣ�m��")]
        public float EdgeBulitSizeHeight
        {
            get { return GetPropertyValue<float>("EdgeBulitSizeHeight"); }
            set { SetPropertyValue("EdgeBulitSizeHeight", value); }
        }

        [Custom("Caption", "��ࣨm��")]
        public float EdgeBulitSizeSpace
        {
            get { return GetPropertyValue<float>("EdgeBulitSizeSpace"); }
            set { SetPropertyValue("EdgeBulitSizeSpace", value); }
        }

        [Custom("Caption", "������ʽ")]
        public string EdgeBuiltType
        {
            get { return GetPropertyValue<string>("EdgeBuiltType"); }
            set { SetPropertyValue("EdgeBuiltType", value); }
        }





        [Custom("Caption", "ʹ�úۼ�")]
        public string EdgeUse
        {
            get { return GetPropertyValue<string>("EdgeUse"); }
            set { SetPropertyValue("EdgeUse", value); }
        }

        [Custom("Caption", "��������")]
        public string EdgeDescription
        {
            get { return GetPropertyValue<string>("EdgeDescription"); }
            set { SetPropertyValue("EdgeDescription", value); }
        }


        //�ӿ�
        [Custom("Caption", "ƽ����״")]
        public AccPlaneShape EntryPlaneShape
        {
            get { return GetPropertyValue<AccPlaneShape>("EntryPlaneShape"); }
            set { SetPropertyValue("EntryPlaneShape", value); }
        }


        [Custom("Caption", "�����ۼ�")]
        public string EntryModify
        {
            get { return GetPropertyValue<string>("EntryModify"); }
            set { SetPropertyValue("EntryModify", value); }
        }

        [Custom("Caption", "ʹ�úۼ�")]
        public string EntryUse
        {
            get { return GetPropertyValue<string>("EntryUse"); }
            set { SetPropertyValue("EntryUse", value); }
        }

        [Custom("Caption", "��������")]
        public string EntryDescription
        {
            get { return GetPropertyValue<string>("EntryDescription"); }
            set { SetPropertyValue("EntryDescription", value); }
        }

        //�ӱ�
        //������״

        [Custom("Caption", "���淽��һ")]
        public string WallDirectionOne
        {
            get { return GetPropertyValue<string>("WallDirectionOne"); }
            set { SetPropertyValue("WallDirectionOne", value); }
        }

        [Custom("Caption", "������״һ")]
        public AccProfileSideShape WallShapeOne
        {
            get { return GetPropertyValue<AccProfileSideShape>("WallShapeOne"); }
            set { SetPropertyValue("WallShapeOne", value); }
        }


        [Custom("Caption", "���淽���")]
        public string WallDirectionTwo
        {
            get { return GetPropertyValue<string>("WallDirectionTwo"); }
            set { SetPropertyValue("WallDirectionTwo", value); }
        }

        [Custom("Caption", "������״��")]
        public AccProfileSideShape WallShapeTwo
        {
            get { return GetPropertyValue<AccProfileSideShape>("WallShapeTwo"); }
            set { SetPropertyValue("WallShapeTwo", value); }
        }

        [Custom("Caption", "�����ۼ�")]
        public string WallModify
        {
            get { return GetPropertyValue<string>("WallModify"); }
            set { SetPropertyValue("WallModify", value); }
        }

        [Custom("Caption", "ʹ�úۼ�")]
        public string WallUse
        {
            get { return GetPropertyValue<string>("WallUse"); }
            set { SetPropertyValue("WallUse", value); }
        }

        [Custom("Caption", "��������")]
        public string WallDescription
        {
            get { return GetPropertyValue<string>("WallDescription"); }
            set { SetPropertyValue("WallDescription", value); }
        }

        //�ӵ�

        [Custom("Caption", "ƽ����״")]
        public AccPlaneShape BottomPlaneShape
        {
            get { return GetPropertyValue<AccPlaneShape>("BottomPlaneShape"); }
            set { SetPropertyValue("BottomPlaneShape", value); }
        }


        [Custom("Caption", "�����ۼ�")]
        public string BottomModify
        {
            get { return GetPropertyValue<string>("BottomModify"); }
            set { SetPropertyValue("BottomModify", value); }
        }

        [Custom("Caption", "ʹ�úۼ�")]
        public string BottomUse
        {
            get { return GetPropertyValue<string>("BottomUse"); }
            set { SetPropertyValue("BottomUse", value); }
        }

        [Custom("Caption", "������")]
        public string BottomRemain
        {
            get { return GetPropertyValue<string>("BottomRemain"); }
            set { SetPropertyValue("BottomRemain", value); }
        }

        [Custom("Caption", "��������")]
        public string BottomDescription
        {
            get { return GetPropertyValue<string>("BottomDescription"); }
            set { SetPropertyValue("BottomDescription", value); }
        }


        //�ѻ�

        [Custom("Caption", "���½����ѻ�")]

        [Association("ExcavationFeaturePileHole-Accumulation2", typeof(Accumulation))]
        public XPCollection Accumulation2
        {
            get { return GetCollection("Accumulation2"); }
        }

        //������
        [Custom("Caption", "���½����ѻ�")]

        [Association("ExcavationFeaturePileHole-RemainMark2", typeof(RemainMark))]
        public XPCollection RemainMark2
        {
            get { return GetCollection("RemainMark2"); }
        }

        //����
        [Custom("Caption", "���½�������")]
        public string BottomBuildingDescription
        {
            get { return GetPropertyValue<string>("BottomBuildingDescription"); }
            set { SetPropertyValue("BottomBuildingDescription", value); }
        }


        //���⽨���ṹ�Լ��˹��ۼ�
        [Custom("Caption", "���⽨���ṹ�Լ��˹��ۼ�")]

        [Association("ExcavationFeaturePileHole-SpacialBuildingStructureAndArtificialVestige",
            typeof(SpacialBuildingStructureAndArtificialVestige))]
        public XPCollection SpacialBuildingStructureAndArtificialVestige
        {
            get { return GetCollection("SpacialBuildingStructureAndArtificialVestige"); }
        }

        //����
        [Custom("Caption", "����")]
        [Association("ExcavationFeaturePileHole-Sign", typeof(Sign))]
        public XPCollection Sign
        {
            get { return GetCollection("Sign"); }
        }

        [Custom("Caption", "��������໥��ϵ")]
        public string SignRelation
        {
            get { return GetPropertyValue<string>("SignRelation"); }
            set { SetPropertyValue("SignRelation", value); }
        }

        [Custom("Caption", "��������")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }


        [Custom("Caption", "�����жϼ�����")]
        public string PropertyAndReason
        {
            get { return GetPropertyValue<string>("PropertyAndReason"); }
            set { SetPropertyValue("PropertyAndReason", value); }
        }

        [Custom("Caption", "�����ټ�����Ϲ�ϵ������")]
        public string SignComponentAndReason
        {
            get { return GetPropertyValue<string>("SignComponentAndReason"); }
            set { SetPropertyValue("SignComponentAndReason", value); }
        }

        [Custom("Caption", "�ż����ۼ������ܽ�")]
        public string Summary
        {
            get { return GetPropertyValue<string>("Summary"); }
            set { SetPropertyValue("Summary", value); }
        }

        [Custom("Caption", "��ע")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        [Custom("Caption", "�����")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }

        [Custom("Caption", "���ʱ��")]
        public DateTime CheckOn
        {
            get { return GetPropertyValue<DateTime>("CheckOn"); }
            set { SetPropertyValue("CheckOn", value); }
        }
    }

}
