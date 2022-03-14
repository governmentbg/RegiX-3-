<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/MON/HigherEdu/HigherEduStudentByStatusRequest" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<xsl:for-each select="n1:HigherEduStudentByStatusRequest">
						<br/>
						<h3 align="center">
							<span>
								<xsl:text>Входни параметри на справка за всички студенти или докторанти със статус &quot;действащ&quot; и &quot;отчислен с право на защита&quot;, по подаден идентификатор</xsl:text>
							</span>
						</h3>
						<table border="0" width="100%">
							<tbody>
								<tr>
									<td>
										<span style="font-style:italic; ">
											<xsl:text>ЕГН/ЛНЧ/Друг вид идентификатор </xsl:text>
										</span>
									</td>
									<td>
										<xsl:for-each select="n1:StudentIdentifier">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td>
										<span style="font-style:italic; ">
											<xsl:text>Статус на студент/докторант</xsl:text>
										</span>
									</td>
									<td>
										<xsl:choose>
											<xsl:when test="n1:StudentStatus  = &apos;active&apos;">
												<span style="font-weight:bold; ">
													<xsl:text>Действащ</xsl:text>
												</span>
											</xsl:when>
											<xsl:when test="n1:StudentStatus =&apos;graduationright&apos;">
												<span style="font-weight:bold; ">
													<xsl:text>Отчислен с право на защита</xsl:text>
												</span>
											</xsl:when>
										</xsl:choose>
									</td>
								</tr>
							</tbody>
						</table>
						<br/>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>